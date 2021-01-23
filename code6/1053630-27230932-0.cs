    public class Names
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
    }
    for (int i = 1; i <= collection.Count(); i++)
    {
        var col = collection.ElementAt(i);
        col.GetType().GetProperty("Name + i").SetValue(col, longString.Substring(11, 4), null);
    }
