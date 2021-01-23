    class Program
    {
        static int? Sum = null;
        static Object lockObject = new Object();
        static void Main()
        {
            Thread t1 = new Thread(ReadFile);
            Thread t2 = new Thread(ReadFile);
            Thread t3 = new Thread(ReadFile);
            t1.Start(@"C:\Users\Mike\Documents\SomeFile1.txt");
            t2.Start(@"C:\Users\Mike\Documents\SomeFile2.txt");
            t3.Start(@"C:\Users\Mike\Documents\SomeFile3.txt");
            t1.Join();
            t2.Join();
            t3.Join();
            if (Sum.HasValue)
            {
                System.Console.WriteLine("Sum: " + Sum.ToString());
            }
            else
            {
                System.Console.WriteLine("No values were successfully retrieved from the files!");
            }
            Console.WriteLine("");
            Console.Write("Press Enter to Quit");
            System.Console.ReadLine();
        }
        public static void ReadFile(Object fileName)
        {
            try
            {
                using (System.IO.StreamReader file1 = new System.IO.StreamReader(fileName.ToString()))
                {
                    int x = 0;
                    string line = file1.ReadLine();
                    if (int.TryParse(line, out x))
                    {
                        lock (lockObject)
                        {
                            if (!Sum.HasValue)
                            {
                                Sum = x;
                            }
                            else
                            {
                                Sum = Sum + x;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Integer in File: " + fileName.ToString() + "\r\nLine from File: " + line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Reading File: " + fileName.ToString() + "\r\nException: " + ex.Message);
            }
        }
    }
