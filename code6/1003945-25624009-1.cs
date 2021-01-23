                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        sw.WriteLine(i.ToString());
                    }
                   
                }
    
                int count = File.ReadLines(path).Count();
                using (StreamWriter sw = File.CreateText(path))
                {
                   
                    sw.WriteLine(count.ToString());
                }
            
