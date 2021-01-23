            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader("TestFile.txt")) 
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                    sb.Append(line);
                }
            }
            var chars = sb.ToString().ToCharArray();
