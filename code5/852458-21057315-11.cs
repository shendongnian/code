        static void Main(string[] args) {
            DataStore storage = DataStore.Instance;
            Console.WriteLine("Main program waking up...\n\n");
            Console.WriteLine("Launching Thread of Writers...");
            Thread writters1 = new Thread(new ThreadStart(delegate() {
                Console.WriteLine("Writters thread, openning media...\n");
                CDMedia cd = (CDMedia)storage.Open(typeof(CDMedia));
                Thread writer1 = new Thread(new ThreadStart(delegate() {
                    Console.WriteLine("Writters thread, writer 1 writting...");
                    //safe write
                    storage.WriteData(typeof(CDMedia), "DataWriter 1, I love to write data all day long, specially on sunny days..."); 
                }));
                Thread writer2 = new Thread(new ThreadStart(delegate() {
                    Console.WriteLine("Writters thread, writer 2 writting...");
                    //safe write
                    storage.WriteData(typeof(CDMedia), "DataWriter 2, I love to write data all day long, specially on windy days...");
                }));
                Thread writer3 = new Thread(new ThreadStart(delegate() {
                    Console.WriteLine("Writters thread, writer 3 writting...");
                    //safe write
                    storage.WriteData(typeof(CDMedia), "DataWriter 3, I love to write data all day long, specially on rainy days...");
                }));
                writer1.Start();
                writer2.Start();
                writer3.Start();
                writer1.Join();
                writer2.Join();
                writer3.Join();
                //all done release media
                Console.WriteLine("\nWritters thread, ended, releasing resource\n");
                storage.Close(cd);
            }));
            Console.WriteLine("Launching Thread of Writers 2...");
            Thread writters2 = new Thread(new ThreadStart(delegate() {
                Console.WriteLine("Writters thread, openning media...\n");
                CDMedia cd = (CDMedia)storage.Open(typeof(CDMedia));
                Thread writer1 = new Thread(new ThreadStart(delegate() {
                    Console.WriteLine("Writters thread, writer 4 writting...");
                    //safe write
                    storage.WriteData(typeof(CDMedia), "DataWriter 4, I love to write data all day long, specially on sunny days...");
                }));
                Thread writer2 = new Thread(new ThreadStart(delegate() {
                    Console.WriteLine("Writters thread, writer 5 writting...");
                    //safe write
                    storage.WriteData(typeof(CDMedia), "DataWriter 5, I love to write data all day long, specially on windy days...");
                }));
                Thread writer3 = new Thread(new ThreadStart(delegate() {
                    Console.WriteLine("Writters thread, writer 6 writting...");
                    //safe write
                    storage.WriteData(typeof(CDMedia), "DataWriter 6, I love to write data all day long, specially on rainy days...");
                }));
                writer1.Start();
                writer2.Start();
                writer3.Start();
                writer1.Join();
                writer2.Join();
                writer3.Join();
                //all done release media
                Console.WriteLine("\nWritters thread, ended, releasing resource\n");
                storage.Close(cd);
            }));
            writters1.Start();
            writters2.Start();
            writters1.Join();
            writters2.Join();
            
            Console.WriteLine("Main program, let's check CDMedia Content shall we?!\n");
            
            CDMedia cdMedia = (CDMedia)storage.Open(typeof(CDMedia));
            Console.WriteLine("CD content: \n" + cdMedia.Data.ToString() + "\n");
            storage.Close(cdMedia);
            Console.WriteLine("The End!");
            Console.ReadKey();
        }
