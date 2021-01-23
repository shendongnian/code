    public class Program
    {
         public static AppState stateVariables = new AppState();
         public static void Main()
         {
              string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
              string folder = Path.Combine(folder, "myappNameDataFolder");
              Directory.CreateDirectory(folder);
              string dataFile = Path.Combine(folder, "myappNameDataFile");
              if (File.Exists(dataFile))
              {
                  using(Stream stateStream = File.OpenRead(dataFile))
                  {
                      BinaryFormatter deserializer = new BinaryFormatter();
                      stateVariables = (AppState)deserializer.Deserialize(stateStream);
                  }
              }
         }
    }
