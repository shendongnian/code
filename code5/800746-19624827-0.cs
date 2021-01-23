            Console.WriteLine("What file would you like to load?");
            string fileName = Console.ReadLine();
            
            using (Stream file = File.Open(fileName, FileMode.Open))
            {
                var reader = new StreamReader(file);
                string line = reader.ReadLine();
                // ...
            }
