    public class ColorLookUpTable
    {
        private readonly IDictionary<string, string> _colorTable;
        private ColorLookUpTable(IDictionary<string, string> colorTable)
        {
            _colorTable = colorTable;
        }
        public static ColorLookUpTable LoadFromFile(string fileName)
        {
            var colorTable = new Dictionary<string, string>();
            using (var reader = File.OpenText(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var colorPairs = line
                        .Split(new [] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(f => !string.IsNullOrWhiteSpace(f))
                        .Select(f => f.Trim());
                    foreach (var colorPair in colorPairs)
                    {
                        var fields = colorPair.Split(new [] { '#' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (fields.Length == 2)
                            colorTable[fields[1]] = colorTable[fields[0]];
                    }
                }
            }
            return new ColorLookUpTable(colorTable);
        }
        public string FindColorCodeExactMatch(string colorName)
        {
            string colorCode = null;
            if (_colorTable.TryGetValue(colorName, out colorCode))
                return colorCode;
            return null;
        }
        public string FindColorCodePartialMatch(string colorName)
        {
            var colorCode = FindColorCodeExactMatch(colorName);
            if (colorCode == null) // No exact match. Need to do work
                // very simple partial mathching.
                colorCode = _colorTable.Keys.Where(k => k.Contains(colorName)).FirstOrDefault();
            return colorCode;
        }
    }
