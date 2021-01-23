    static void Main(string[] args)
    {
    	var config = new TasksConfig();
    	config.Items.Add( new FileTask() { /* properties */ });
    	config.Items.Add( new DbTask() { /* properties */ });
    
    	XmlSerializer serializer = new XmlSerializer(typeof(TasksConfig));
    	MemoryStream memoryStream = new MemoryStream();
    	serializer.Serialize(memoryStream, config);
    
    	System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
    	String serializedString = enc.GetString(memoryStream.ToArray());
    }
