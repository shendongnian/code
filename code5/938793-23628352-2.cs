    using System;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            void run()
            {
                Task.Run(() => consumer());
                Task.Run(() => producer());
                Console.WriteLine("Press <ENTER> to stop.");
                Console.ReadLine();
            }
            static void producer()
            {
                using (var mmf = MemoryMappedFile.CreateOrOpen("MyMapName", 1024))
                using (var view = mmf.CreateViewStream())
                {
                    var writer = new BinaryWriter(view);
                    var signal = new EventWaitHandle(false, EventResetMode.AutoReset, "MyEventName");
                    var mutex = new Mutex(false, "MyMutex");
                    for (int i = 0; i < 100; ++i)
                    {
                        string message = "Message #" + i;
                        mutex.WaitOne();
                        writer.BaseStream.Position = 0;
                        writer.Write(message);
                        signal.Set();
                        mutex.ReleaseMutex();
                        Thread.Sleep(1000);
                    }
                }
            }
            static void consumer()
            {
                using (var mmf = MemoryMappedFile.CreateOrOpen("MyMapName", 1024))
                using (var view = mmf.CreateViewStream())
                {
                    var reader = new BinaryReader(view);
                    var signal = new EventWaitHandle(false, EventResetMode.AutoReset, "MyEventName");
                    var mutex = new Mutex(false, "MyMutex");
                    while (true)
                    {
                        signal.WaitOne();
                        mutex.WaitOne();
                        reader.BaseStream.Position = 0;
                        var message = reader.ReadString();
                        Console.WriteLine("Received message: " + message);
                        mutex.ReleaseMutex();
                    }
                }
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
