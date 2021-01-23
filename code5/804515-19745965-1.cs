    public class App
    {
      public static DataService DataService { get; set; }
    
      static App()
      {
        DataService = new DataService();
      }
      // other app.xaml.cs stuff
    }
