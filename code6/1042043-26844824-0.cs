    using (var testConnection = new SqlConnection()) {
    	testConnection.ConnectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;";
    	testConnection.Open();
    	using (var testCommand = new SqlCommand("exec prAdvListToXML", testConnection))
    	using (XmlReader testXmlReader = testCommand.ExecuteXmlReader())
    	using (XmlWriter testFileWriter = XmlWriter.Create(@"C:\temp\output.xml")) {
    		testFileWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-16'");
    		testFileWriter.WriteNode(testXmlReader, true);
    	}
    }
