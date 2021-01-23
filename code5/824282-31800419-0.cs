    void Main()
    {
    	var xml = Save();
    	Console.WriteLine(xml);
    	var data = Load(xml);
    	Console.WriteLine("\r\nLevel count: " + data.Levels.Count.ToString());
    }
    
    // Define other methods and classes here
    public struct LevelData
    {
        /// <summary>
        /// The index of the level.
        /// </summary>
        [XmlElement(ElementName = "Index")]
        public int Index;
    
        /// <summary>
        /// The number of attempts the player has made for a particular level.
        /// </summary>
        [XmlElement(ElementName = "Attempts")]
        public int Attempts;
    
        /// <summary>
        /// A value describing the furthest the player has ever got within the level.
        /// </summary>
        [XmlElement(ElementName = "PercentComplete")]
        public int PercentComplete;
    }
    
    public struct Data
    {
        /// <summary>
        /// The Level data object.
        /// </summary>
        [XmlArray(ElementName = "Levels")]
        public List<LevelData> Levels;
    }
    
    public string Save()
    {
    	Data data = new Data();
    	// Create a list to store the data already saved.
    	data.Levels = new List<LevelData>();
    	
    	// Initialize the new data values.
    	LevelData levelData = new LevelData();
    	levelData.Index = 1;
    	levelData.Attempts = 3;
    	levelData.PercentComplete = 50;
    	
    	// Add the level data.
    	data.Levels.Add(levelData);
    	
    	// Convert the object to XML data and put it in the stream.
    	XmlSerializer serializer = new XmlSerializer(typeof(Data));
    	var sb = new StringBuilder();
    	using (var sr = new StringWriter(sb))
    	{
    		// Seriaize the data.
    		serializer.Serialize(sr, data);
    	}
    	return sb.ToString();
    }
    
    public Data Load(string xml)
    {
    	// Convert the object to XML data and put it in the stream.
    	XmlSerializer serializer = new XmlSerializer(typeof(Data));
    	using (var sr = new StringReader(xml))
    	{
    		return (Data)serializer.Deserialize(sr);
    	}
    }
