            Console.WriteLine("What file would you like to load?");
            string fileName = Console.ReadLine();
            
            using (Stream reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                // ...
            }
