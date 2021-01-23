    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                // Make some pretend URLs for this demo.
                
                string[] urls = Enumerable.Range(1, 100).Select(n => n.ToString()).ToArray();
                // Use Parallel.ForEach() along with MaxDegreeOfParallelism = 5 to process
                // these using 5 threads maximum:
                Parallel.ForEach(
                    urls,
                    new ParallelOptions{MaxDegreeOfParallelism = 5},
                    processUrl
                );
            }
            static void processUrl(string url)
            {
                Console.WriteLine("Processing " + url);
                Thread.Sleep(1000);
                Console.WriteLine("Processed " + url);
            }
        }
    }
