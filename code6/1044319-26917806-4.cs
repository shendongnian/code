    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    namespace TestOldSchoolNetworkStream
    {
        class Program
        {
            private const int _kport = 54321;
            static void Main(string[] args)
            {
                SocketServer server = new SocketServer(_kport);
                Socket remote = new Socket(SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, _kport);
                remote.Connect(remoteEndPoint);
                using (NetworkStream stream = new NetworkStream(remote))
                {
                    // For convenience, These variables are local and captured by the
                    // anonymous method callback. A less-primitive implementation would
                    // encapsulate the client state in a separate class, where these objects
                    // would be kept. The instance of this object would be then passed to the
                    // completion callback, or the receive method itself would contain the
                    // completion callback itself.
                    ManualResetEvent receiveMonitor = new ManualResetEvent(false);
                    byte[] rgbReceive = new byte[8192];
                    char[] rgch = new char[Encoding.UTF8.GetMaxCharCount(rgbReceive.Length)];
                    Decoder decoder = Encoding.UTF8.GetDecoder();
                    StringBuilder receiveBuffer = new StringBuilder();
                    stream.BeginRead(rgbReceive, 0, rgbReceive.Length, result =>
                    {
                        _Receive(stream, rgbReceive, rgch, decoder, receiveBuffer, receiveMonitor, result);
                    }, null);
                    string text;
                    Console.WriteLine("CLIENT: connected. Enter text to send...");
                    while ((text = Console.ReadLine()) != "")
                    {
                        byte[] rgbSend = Encoding.UTF8.GetBytes(text + Environment.NewLine);
                        remote.BeginSend(rgbSend, 0, rgbSend.Length, SocketFlags.None, _Send, Tuple.Create(remote, rgbSend.Length));
                    }
                    remote.Shutdown(SocketShutdown.Send);
                    receiveMonitor.WaitOne();
                }
                server.Stop();
            }
            private static void _Receive(NetworkStream stream, byte[] rgb, char[] rgch, Decoder decoder, StringBuilder receiveBuffer, EventWaitHandle monitor, IAsyncResult result)
            {
                try
                {
                    int byteCount = stream.EndRead(result);
                    string fullLine = null;
                    if (byteCount > 0)
                    {
                        int charCount = decoder.GetChars(rgb, 0, byteCount, rgch, 0);
                        receiveBuffer.Append(rgch, 0, charCount);
                        int newLineIndex = IndexOf(receiveBuffer, Environment.NewLine);
                        if (newLineIndex >= 0)
                        {
                            fullLine = receiveBuffer.ToString(0, newLineIndex);
                            receiveBuffer.Remove(0, newLineIndex + Environment.NewLine.Length);
                        }
                        stream.BeginRead(rgb, 0, rgb.Length, result1 =>
                        {
                            _Receive(stream, rgb, rgch, decoder, receiveBuffer, monitor, result1);
                        }, null);
                    }
                    else
                    {
                        Console.WriteLine("CLIENT: end-of-stream");
                        fullLine = receiveBuffer.ToString();
                        monitor.Set();
                    }
                    if (!string.IsNullOrEmpty(fullLine))
                    {
                        Console.WriteLine("CLIENT: received \"" + fullLine + "\"");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("CLIENT: Exception: " + e);
                }
            }
            private static int IndexOf(StringBuilder sb, string text)
            {
                for (int i = 0; i < sb.Length - text.Length + 1; i++)
                {
                    bool match = true;
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (sb[i + j] != text[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        return i;
                    }
                }
                return -1;
            }
            private static void _Send(IAsyncResult result)
            {
                try
                {
                    Tuple<Socket, int> state = (Tuple<Socket, int>)result.AsyncState;
                    int actualLength = state.Item1.EndSend(result);
                    if (state.Item2 != actualLength)
                    {
                        // Should never happen...the async operation should not complete until
                        // the full buffer has been successfully sent, 
                        Console.WriteLine("CLIENT: send completed with only partial success");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("CLIENT: Exception: " + e);
                }
            }
        }
    }
