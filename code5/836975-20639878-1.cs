    public HeatmapComponent() {
    }
    public void Test1(int width, int height) {
      var hm = new HeatMap(width, height);
      Console.WriteLine("Width: {0}, Height: {1}", hm.Width, hm.Height);
    }
    public static void Test2(int width, int height) {
      var hm = new HeatMap();
      hm.Set(width, height);
      Console.WriteLine("Width: {0}, Height: {1}", hm.Width, hm.Height);
    }
