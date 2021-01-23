    static void Main(string[] args)
    {
        var a = loly();
        var partitionSize = 3;
        using (var enumerator = a.GetEnumerator())
        {
            var values = new List<int>(partitionSize);
            for (int i = 0; i < 3; i++)
            {
                values.Clear();
                for (int j = 0; j < partitionSize && enumerator.MoveNext(); j++)
                {
                    values.Add(enumerator.Current);
                }
                foreach (var c in values)
                {
                    Console.Write(c);
                }
            }
        }
        Console.Read();
    }
