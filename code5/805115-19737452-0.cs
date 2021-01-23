    public enum Colors { Red = 1, Yellow = 2 }
    public class Color
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
    static void Main(string[] args)
    {
        var colorClasses = from name in Enum.GetNames(typeof(Colors))
                           select
                           new Color()
                           {
                               Value = (int)Enum.Parse(typeof(Colors), name),
                               Name = name
                           };
    }
