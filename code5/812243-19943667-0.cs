     class Program {
		static void Main(string[] args) {
			var s = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + 
					"<root>" +
					"<statusCode>0</statusCode>" + 
					"<statusDesc/>" + 
					"<Status/>" + 
					"<WSKey/>" + 
					"<Priority/>" + 
					"<Guid>3A336A97-BCA3-43F8-849C-A40D129B25AA</Guid>" + 
					"</root>";
			var xmlReader = new XmlTextReader(
				new MemoryStream(
					Encoding.ASCII.GetBytes(s), false));
			bool flag;
			Int32 statusCode;
			String statusDesc;
			String guid;
			flag = xmlReader.ReadToFollowing("statusCode");
			if (flag) {
				statusCode = xmlReader.ReadElementContentAsInt();
			} else {
				statusCode = 333;
			}
			flag = xmlReader.ReadToFollowing("statusDesc");
			if (flag) {
				statusDesc = xmlReader.ReadElementContentAsString();
			} else {
				statusDesc = "";
			}
			flag = xmlReader.ReadToFollowing("Guid");
			if (flag) {
				guid = xmlReader.ReadElementContentAsString();
			} else {
				guid = "";
			}
		}
	}
