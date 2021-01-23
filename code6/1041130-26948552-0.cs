    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Rxx.Parsers.Reactive.Linq;
    namespace Rxx.Labs.Forums
    {
      public sealed class BinaryParserLab : BaseConsoleLab
      {
        private const int port = 30253;
        private const int bufferSize = 4;
        private static Encoding encoding = Encoding.ASCII;
        protected override void Main()
        {
          using (new CompositeDisposable(StartHost(), StartClient()))
          {
            WaitForKey();
          }
        }
        private IDisposable StartClient()
        {
          return Observable.Using(
            () => new TcpClient(),
            client => (from _ in client.ConnectObservable(IPAddress.Loopback, port)
                       from line in Observable.Using(() => client.GetStream(), ReceiveData)
                       select line))
                       .Subscribe(line => TraceSuccess("Received: {0}", line), () => TraceStatus("Client Completed."));
        }
        private IDisposable StartHost()
        {
          return (from client in ObservableTcpListener.Start(IPAddress.Loopback, port, maxConcurrent: 1).Take(1)
                  from _ in Observable.Using(
                   () => client.GetStream(),
                   stream => Observable.Create<Unit>((observer, cancel) => SendData(stream, observer, cancel)))
                  select Unit.Default)
                  .Subscribe(_ => { }, () => TraceStatus("Host Completed."));
        }
        private async Task SendData(NetworkStream stream, IObserver<Unit> observer, CancellationToken cancel)
        {
          var data = encoding.GetBytes("Line 1\nLine 2\nLine 3\nLine 4\n");
          for (var i = 0; i < data.Length; i += bufferSize)
          {
            TraceLine("Sending: {0}", encoding.GetString(data, i, bufferSize).Replace('\n', ' '));
            await stream.WriteAsync(data, i, bufferSize, cancel).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromSeconds(1), cancel).ConfigureAwait(false);
          }
        }
        private IObservable<string> ReceiveData(NetworkStream stream)
        {
          return (from bytes in stream.ReadToEndObservable(bufferSize)
                  from b in bytes
                  select b)
                  .ParseBinary(parser =>
                  from next in parser
                  let newLine = parser.Byte.Of((byte)'\n')
                  let line = next.Not(newLine).NoneOrMore()
                  select from bytes in line
                         from _ in newLine
                         from array in bytes.ToArray()
                         select encoding.GetString(array));
        }
      }
    }
