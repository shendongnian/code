    using System;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Inline code to test");
                Console.WriteLine(StartTask(true));
                Console.WriteLine("Get actual website to test, write the length of the text only");
                Console.WriteLine(StartTask(false).Length);
                Console.Write("Press any key");
                Console.ReadKey();
            }
            static string StartTask(bool DoTestInsteadOfGetUrl)
            {
                var task = DoTasks(DoTestInsteadOfGetUrl);
                Task.WaitAny(task);
                return task.Result;
            }
            async static Task<string> DoTasks(bool DoTestInsteadOfGetUrl)
            {
                int timeout = 20;
                int count = 1;
                CancellationTokenSource cts;
                string output;                
                do
                {
                    cts = new CancellationTokenSource(timeout);
                    if (DoTestInsteadOfGetUrl)
                    {
                        output = await Task<string>.Run(() => test(count, cts.Token), cts.Token);
                    }
                    else
                    {
                        WebClient client = new WebClient() { Encoding = Encoding.UTF8 };
                        output = await Task<string>.Run(() => client.DownloadStringTaskAsync("http://www.google.com"), cts.Token);
                    }
                    if (cts.IsCancellationRequested)
                    {
                        Console.WriteLine("try #" + count++);
                        timeout += DoTestInsteadOfGetUrl ? 100 : 50;
                    }
                } while (cts.IsCancellationRequested);
                return output;
            }
            async static Task<string> test(int count, CancellationToken ct)
            {
                int sleep = 400 - (count * 5);
                await Task.Run(() => Task.Delay(sleep), ct);
                if (!ct.IsCancellationRequested)
                {
                    Console.WriteLine("succeed #" + count);
                }
                return sleep.ToString();
            }
        }
    }
