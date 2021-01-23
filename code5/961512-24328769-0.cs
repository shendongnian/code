    public static bool SaveXMLObjectToFile(object IncomingXMLObject, string Path)   
    {
	string xmlString = null;
	File TheFileIn = default(File);
	string docname = null;
	StreamWriter WriteAFile = default(StreamWriter);
	string filelocation = null;
	//Dim filelocation As String
	System.IO.MemoryStream MemStream = new System.IO.MemoryStream();
	System.Xml.Serialization.XmlSerializer Ser = default(System.Xml.Serialization.XmlSerializer);
	System.Text.Encoding encodingvalue = System.Text.UTF8Encoding.UTF8;
	System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(MemStream, encodingvalue);
	bool Result = false;
	try {
		File.Delete(Path);
		Ser = new System.Xml.Serialization.XmlSerializer(IncomingXMLObject.GetType);
		Ser.Serialize(writer, IncomingXMLObject);
		MemStream = writer.BaseStream;
		//as system.io.memorystream
		xmlString = UTF8ByteArrayToString(MemStream.ToArray());
		//Will Not Convert Byte Array from Diagram
		filelocation = Path;
		WriteAFile = TheFileIn.AppendText(filelocation);
		WriteAFile.Write(xmlString);
		WriteAFile.Close();
		Result = true;
	} catch (Exception e) {
		Result = false;
	}
	return Result;
    }
