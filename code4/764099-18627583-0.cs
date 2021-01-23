    public class ColorByReference
    {
        Color TheColor {get;set;}
    }
    
    static ColorByReference color = new ColorByReference {Color = new Color(0,0,0,0)};
    static void Main(string[] args)
    {
        ColorByReference otherColor = color;
        color.TheColor.B = 100;
        Console.WriteLine(otherColor.TheColor.B);
        Console.WriteLine(color.TheColor.B);
        Console.ReadLine();
    }
