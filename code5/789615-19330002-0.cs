    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading;
    
    namespace WebDownload
    {
        class Program
        {
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
    
            static void Main(string[] args)
            {
                WebClient client = new WebClient();
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
    
                string fileName = Path.GetTempFileName();
                client.DownloadFileAsync(new Uri("https://www.google.com/images/srpr/logo11w.png"), fileName, fileName);
    
                // Wait for work method to signal. 
                if (autoEvent.WaitOne(20000))
                    Console.WriteLine("Image download completed.");
                else
                {
                    Console.WriteLine("Timed out waiting for image to download.");
                    client.CancelAsync();
                }
            }
    
            private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    Console.WriteLine(e.Error.Message);
                    if (e.Error.InnerException != null)
                        Console.WriteLine(e.Error.InnerException.Message);
                }
                else
                {
                    // We have a file - do something with it
                    WebClient client = (WebClient)sender;
    
                    // display the response header so we can learn
                    Console.WriteLine("Response Header...");
                    foreach(string k in client.ResponseHeaders.AllKeys)
                        Console.WriteLine("   {0}: {1}", k, client.ResponseHeaders[k]);
                    Console.WriteLine(string.Empty);
    
                    // since we know it's a png, let rename it
                    FileInfo temp = new FileInfo((string)e.UserState);
                    string pngFileName = Path.Combine(Path.GetTempPath(), "DesktopPhoto.png");
                    if (File.Exists(pngFileName))
                        File.Delete(pngFileName);
    
                    File.Move((string)e.UserState, pngFileName);  // move to where ever you want
                    Process.Start(pngFileName);     // display the photo for the fun of it
                }
    
                // Signal that work is finished.
                autoEvent.Set();
            }
    
    
        }
    }
