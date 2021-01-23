    public class HeatMap {
      public HeatMap() {
        Width = 0;
        Height = 0;
      }
      public HeatMap(int width, int height) {
        Width = width;
        Height = height;
      }
      public void Set(int width, int height) {
        Width = width;
        Height = height;
      }
      public int Width { get; private set; }
      public int Height { get; private set; }
    }
