            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                if (i < 100)
                {
                    writer.WriteLine("WELCOME????");
                }
                else
                {
                    Console.WriteLine("All DONE");
                }
            }
