    public class main
    {
        public void onClickedSave()
        {
    		SaveGameInfo obj = new SaveGameInfo();
    		obj.test = "TestInformation";
    	   obj.SerializeToXml("Test.xml");	
    	}
    }
    
    public class SaveGameInfo
    {
    	public string test;
    
    	public void SerializeToXml(string fullFileName)
    	{
    		var serializer = new XmlSerializer(typeof(SaveGameInfo));
    		var textWriter = new StreamWriter(fullFileName);
    		serializer.Serialize(textWriter, this);
    		textWriter.Close();
    	}
    }
