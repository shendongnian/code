                StreamReader output = p.StandardOutput;
                string line;
                while ((line = output.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
