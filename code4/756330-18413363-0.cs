    public static class SimpleCsvImport
    {
        public static IEnumerable<List<string>> Import(string csvFileName)
        {
            using (var reader = File.OpenText(csvFileName))
            {
                while (!reader.EndOfStream)
                {
                    var fields = reader.ReadLine().Split(new[] { ',' }, StringSplitOptions.None).Select(f => f.Trim()).ToList();
                    if (fields.Count > 0)
                        yield return fields;
                }
            }
        }
    }
