    public class XY_Values
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    static void MergeFilesForDay(string dir, DateTime date, List<string> files)
    {
        var idValues = new Dictionary<string, XY_Values>();
        foreach (string fn in files)
        {
            foreach (string line in File.ReadAllLines(fn))
            {
                string[] fields = line.Split(new string[] { "," }, StringSplitOptions.None);
                if (fields.Length < 3) continue; // skip invalid data
                string id = fields[0].Trim();
                int x, y;
                bool xValid = int.TryParse(fields[1].Trim(), out x);
                bool yValid = int.TryParse(fields[2].Trim(), out y);
                if (xValid && yValid)
                {
                    bool knownID = idValues.ContainsKey(id);
                    if (!knownID) idValues.Add(id, new XY_Values());
                    XY_Values values = idValues[id];
                    values.X += x;
                    values.Y += y;
                }
            }
        }
        string file = Path.Combine(dir, date.ToString("yyyyMMdd") + ".csv");
        using (var stream = File.CreateText(file))
        {
            foreach (KeyValuePair<string, XY_Values> idValue in idValues)
            {
                string line = string.Format("{0},{1},{2}", idValue.Key, idValue.Value.X, idValue.Value.Y);
                stream.WriteLine(line);
            }
        }
    }
