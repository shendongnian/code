    using System;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tempFile = System.IO.Path.GetTempFileName();
                Console.WriteLine(tempFile);
    
                var fs = new System.IO.FileStream(
                    tempFile, 
                    System.IO.FileMode.Create, 
                    System.IO.FileAccess.ReadWrite, 
                    System.IO.FileShare.ReadWrite, 
                    bufferSize: 256,
                    useAsync: true);
    
                fs.SetLength(8192);
    
                var buff1 = Enumerable.Repeat((byte)0, 2048).ToArray();
                var buff2 = Enumerable.Repeat((byte)0xFF, 2048).ToArray();
    
                try
                {
                    fs.Seek(0, System.IO.SeekOrigin.Begin);
                    var task1 = fs.WriteAsync(buff1, 0, buff1.Length);
    
                    fs.Seek(buff1.Length, System.IO.SeekOrigin.Begin);
                    var task2 = fs.WriteAsync(buff2, 0, buff2.Length);
    
                    Task.WhenAll(task1, task2).Wait();
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
