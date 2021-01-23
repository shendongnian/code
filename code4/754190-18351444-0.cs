                using (StreamReader sr = new StreamReader("TestFile.html"))
            {
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
