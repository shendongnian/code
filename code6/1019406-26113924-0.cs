    public class SaveGameInfo
    {
        public string Test { get; set; }
    }
    
    public class main
    {
        public void onClickedSave()
        {
            SaveGameInfo obj = new SaveGameInfo();
            obj.Test = "TestInformation";
            SharpSerializer sharpSerializer = new SharpSerializer();
            sharpSerializer.Serialize(obj, "test.xml");
        }
    }
