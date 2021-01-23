    [Flags]
    public enum ColorComponents
    {
        Red = 1,
        Green = 2,
        Blue = 4
    }
    
    public class Foo
    {
        public IEnumerable<ColorComponents> Colors { get; set; }
    }
