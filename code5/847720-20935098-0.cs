    List<List<int>> lists = new List<List<int>>();
    using (StreamReader reader = new StreamReader("wt40.txt"))
    {
        string line;
        int count = 0;
        while ((line = reader.ReadLine()) != null)
        {
            List<int> currentList =
                Regex.Split(line, "\\s")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(int.Parse).ToList();
            if (currentList.Count > 0) // skip empty lines
            {
                if (count % 2 == 0) // append each second list to the previous one
                {
                    lists.Add(currentList);
                }
                else
                {
                    lists[count / 2].AddRange(currentList);
                }
            }
            count++;
        }
    }
