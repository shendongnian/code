    public class AppSettings
    {
        public bool SomeProp { get; set; }
        public double AnotherProp { get; set;}
    
        public void Save()
        {
            FileStorage.WriteSharedData("Settings.txt", this);
        }
    
        public static AppSettings Load()
        {
            return FileStorage.ReadData<AppSettings>("Settings.txt");
        }
    }
