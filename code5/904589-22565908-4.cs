    using (var reader = message.GetReaderAtBodyContents())
    {
    	reader.Read();
    
    	var whatever = System.Text.Encoding.UTF8.GetString(reader.ReadContentAsBase64());
    	testClassInstance = Newtonsoft.Json.JsonConvert.DeserializeObject<TestClass>(whatever);
    	Console.WriteLine("Server: testClassInstance.test = {0}", testClassInstance.test);
    }
