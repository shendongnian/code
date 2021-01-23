            List<string> list = new List<string>() { "A", "16", "49", "FRED", "AD", "17", "17", "17", "FRED", "8", "B", "22", "22", "107", "64" };
            List<List<string>> result = new List<List<string>>();
            for (int i = 0; i < list.Count / 5; i++)
            {
                result.Add(list.Skip(i * 5).Take(5).ToList());
            }
