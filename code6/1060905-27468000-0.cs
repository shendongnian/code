    public class Car
    {
        public CarColorOptions ColorOptions { set; get; }
    }
    
    [Flags]
    public enum CarColorOptions
    {
        Black,
        Red,
        Blue,
        ...
    }
