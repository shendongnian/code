        using System;
        using System.Text;
        using System.Threading;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using HtmlAgilityPack;
        namespace ConsoleApplication276
        {
        
            // a container for a url and a parser Action
            public class Link
            {
                public string link{get;set;}
                public Action<string> parser { get; set; }
            }
        
            public class Program
            {
        
                // Entry Point of the console app
                public static void Main(string[] args)
                {
                    try
                    {
                        // download each page and dump the content
                        // you can add more links here, associate each link with a parser action, as for what data should the parser generate create a property for that in the Link container
                        
                        var task = MessageLoopWorker.Run(DoWorkAsync, new Link() { 
                            link = "google.com", 
                            parser = (string html) => {
        
                                //do what ever you need with hap here
                                var doc = new HtmlAgilityPack.HtmlDocument();
                                doc.LoadHtml(html);
                                var someNodes = doc.DocumentNode.SelectSingleNode("//div");
                                
                            } });
                        
        
                        task.Wait();
                        Console.WriteLine("DoWorkAsync completed.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DoWorkAsync failed: " + ex.Message);
                    }
        
                    Console.WriteLine("Press Enter to exit.");
                    Console.ReadLine();
                }
        
                // navigate WebBrowser to the list of urls in a loop
                public static async Task<Link> DoWorkAsync(Link[] args)
                {
                    Console.WriteLine("Start working.");
        
                    using (var wb = new WebBrowser())
                    {
                        wb.ScriptErrorsSuppressed = true;
        
                        TaskCompletionSource<bool> tcs = null;
                        WebBrowserDocumentCompletedEventHandler documentCompletedHandler = (s, e) =>
                            tcs.TrySetResult(true);
        
                        // navigate to each URL in the list
                        foreach (var arg in args)
                        {
                            tcs = new TaskCompletionSource<bool>();
                            wb.DocumentCompleted += documentCompletedHandler;
                            try
                            {
                                wb.Navigate(arg.link.ToString());
                                // await for DocumentCompleted
                                await tcs.Task;
                                // after the page loads pass the html to the parser 
                                arg.parser(wb.DocumentText);
                            }
                            finally
                            {
                                wb.DocumentCompleted -= documentCompletedHandler;
                            }
                            // the DOM is ready
                            Console.WriteLine(arg.link.ToString());
                            Console.WriteLine(wb.Document.Body.OuterHtml);
                        }
                    }
        
                    Console.WriteLine("End working.");
                    return null;
                }
        
            }
        
            // a helper class to start the message loop and execute an asynchronous task
            public static class MessageLoopWorker
            {
                public static async Task<Object> Run(Func<Link[], Task<Link>> worker, params Link[] args)
                {
                    var tcs = new TaskCompletionSource<object>();
        
                    var thread = new Thread(() =>
                    {
                        EventHandler idleHandler = null;
        
                        idleHandler = async (s, e) =>
                        {
                            // handle Application.Idle just once
                            Application.Idle -= idleHandler;
        
                            // return to the message loop
                            await Task.Yield();
        
                            // and continue asynchronously
                            // propogate the result or exception
                            try
                            {
                                var result = await worker(args);
                                tcs.SetResult(result);
                            }
                            catch (Exception ex)
                            {
                                tcs.SetException(ex);
                            }
        
                            // signal to exit the message loop
                            // Application.Run will exit at this point
                            Application.ExitThread();
                        };
        
                        // handle Application.Idle just once
                        // to make sure we're inside the message loop
                        // and SynchronizationContext has been correctly installed
                        Application.Idle += idleHandler;
                        Application.Run();
                    });
        
                    // set STA model for the new thread
                    thread.SetApartmentState(ApartmentState.STA);
        
                    // start the thread and await for the task
                    thread.Start();
                    try
                    {
                        return await tcs.Task;
                    }
                    finally
                    {
                        thread.Join();
                    }
                }
            }
        }
