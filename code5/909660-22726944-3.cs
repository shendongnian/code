    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Threading;
    
    namespace ConsoleApplication_22717365
    {
        // by Noseratio - https://stackoverflow.com/q/22717365/1768303
        public class Program
        {
            const string RTF = @"{\rtf1\ansi{\fonttbl\f0\fswiss Helvetica;}\f0\pard This is some {\b bold} text.\par}";
    
            static void Main()
            {
                var xaml = RunOnWpfThreadAsync(() => ConvertRtfToXaml(RTF)).Result;
                Console.WriteLine(xaml);
            }
    
            // http://code.msdn.microsoft.com/windowsdesktop/Converting-between-RTF-and-aaa02a6e
            private static string ConvertRtfToXaml(string rtfText)
            {
                var richTextBox = new RichTextBox();
                if (string.IsNullOrEmpty(rtfText)) return "";
                var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                using (var rtfMemoryStream = new MemoryStream())
                {
                    using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                    {
                        rtfStreamWriter.Write(rtfText);
                        rtfStreamWriter.Flush();
                        rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                        textRange.Load(rtfMemoryStream, DataFormats.Rtf);
                    }
                }
                using (var rtfMemoryStream = new MemoryStream())
                {
                    textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                    textRange.Save(rtfMemoryStream, DataFormats.Xaml);
                    rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                    using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                    {
                        return rtfStreamReader.ReadToEnd();
                    }
                }
            }
    
            // https://stackoverflow.com/a/22626704/1768303
            public static async Task<TResult> RunOnWpfThreadAsync<TResult>(Func<Task<TResult>> funcAsync)
            {
                var tcs = new TaskCompletionSource<Task<TResult>>();
    
                Action startup = async () =>
                {
                    // this runs on the WPF thread
                    var task = funcAsync();
                    try
                    {
                        await task;
                    }
                    catch
                    {
                        // propagate exception with tcs.SetResult(task)
                    }
                    // propagate the task (so we have the result, exception or cancellation)
                    tcs.SetResult(task);
    
                    // request the WPF tread to end
                    // the message loop inside Dispatcher.Run() will exit
                    System.Windows.Threading.Dispatcher.ExitAllFrames();
                };
    
                // the WPF thread entry point
                ThreadStart threadStart = () =>
                {
                    // post the startup callback
                    // it will be invoked when the message loop starts pumping
                    System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(
                        startup, DispatcherPriority.Normal);
                    // run the WPF Dispatcher message loop
                    System.Windows.Threading.Dispatcher.Run();
                };
    
                // start and run the STA thread
                var thread = new Thread(threadStart);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
                try
                {
                    // propagate result, exception or cancellation
                    return await tcs.Task.Unwrap().ConfigureAwait(false);
                }
                finally
                {
                    // make sure the thread has fully come to an end
                    thread.Join();
                }
            }
    
            // a wrapper to run synchronous code
            public static Task<TResult> RunOnWpfThreadAsync<TResult>(Func<TResult> func)
            {
                return RunOnWpfThreadAsync(() => Task.FromResult(func()));
            }
        }
    }
