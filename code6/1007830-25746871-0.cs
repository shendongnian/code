         public class Palette
         {
           public List<Thread> Threads { get; set; }
         }
          public class Thread
       {
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Code { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public string Type { get; set; }
    public int Thickness { get; set; }
    }
       public class Colors
    {
    public int Width { get; set; }
    public int Height { get; set; }
    public int NumStitches { get; set; }
    public Palette Palette { get; set; }
    public List<int> Needles { get; set; }
    }
