    public IEnumerable<List<string>> Split(List<string> items, int multiplier = 5)
        {
            //List<string> items = new List<string>() { "A", "16", "49", "FRED", "AD", "17", "17", "17", "FRED", "8", "B", "22", "22", "107", "64" };
            for (int i = 0; i < items.Count / multiplier; i++)
            {
                yield return items.Skip(i * multiplier).Take(multiplier).ToList();
            }
        }
