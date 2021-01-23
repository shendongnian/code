      public static void DumpMemoryCacheToFile(string filePath)
        {
            try
            {
                using (var file = new StreamWriter(filePath, true))
                {
                    foreach (var item in OutputCache)
                    {
                        string line = JsonConvert.SerializeObject(item.Key);
                        file.WriteLine(line);
                    }
                }
            }
            catch
            {
                // Do nothing
            }
        }
