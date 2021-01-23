       public struct Color
       {
          int r, g, b;
          public Color(int r, int g, int b)
          {
             this.r = r;
             this.g = g;
             this.b = b;
          }
       }
    
       public static class BetterColors
       {
          static Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>();
    
          static BetterColors()
          {
             colorDictionary.Add("Red", new Color(255, 2, 4));
             colorDictionary.Add("Blue", new Color(0, 3, 251));
             colorDictionary.Add("Green", new Color(0, 200, 0));
          }
    
          static public Color GetColor(string colorName)
          {
             return colorDictionary[colorName];
          }
       }
    
       class Box
       {
          public Color boxColor { get; set; }
       }
    
       class Program
       {
          static void Main()
          {
             string[] myColors = { "Red", "Green", "Blue" };
    
             Box myBox = new Box();
             myBox.boxColor = BetterColors.GetColor(myColors[1]);
          }
       }
