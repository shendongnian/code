    public static IEnumerable<int> ReadNumbers()
    {
        using (var reader = new StreamReader(File.OpenRead("Numbers.txt."))) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                foreach (var number in line.Split(' ')) {
                    yield return int.Parse(number);
                }
            }
        }
    }
