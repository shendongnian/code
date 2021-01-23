        public void WriteFile(string line, string fileName)
        {
            try
            {
                using (var sw = new StreamWriter(file, true))
                {
                    sw.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
    
            Console.WriteLine("Done");
        }
