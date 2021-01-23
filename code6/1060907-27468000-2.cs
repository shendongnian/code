    public class Car
    {
        public ColorOptions AvailableColorOptions { set; get; }
    }
    
    [Flags]
    public enum ColorOptions
    {
        Black,
        Red,
        Blue,
        ...
    }
