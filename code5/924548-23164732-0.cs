     string[] array = Directory.GetFiles(@"D:\Sample", "*.txt");
            foreach (string file in array)
            {
                Application.DoEvents();
                string contents = File.ReadAllText(file);
                if (contents.Contains("testing"))
                {
                    Console.WriteLine(file);
                }
            }
