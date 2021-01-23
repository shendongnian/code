    string text = Properties.Resources.text;
            using(TextReader sr = new StringReader(text))
            {
                var firstline = sr.ReadLine();
                Console.WriteLine("FIRSTLINE: " + firstline);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
