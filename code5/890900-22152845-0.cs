	public class File
	{
		public File(string fileName, string xmlName, string xsdName)
		{
			FileName = fileName;
			XmlName = xmlName;
			XsdName = xsdName;
		}
		
		public string FileName
		{
			get;
			private set;
		}
		
		public string XmlName
		{
			get;
			private set;
		}
		
		public string XsdName
		{
			get;
			private set;
		}
	}
	public class OtherClass
	{
		public File FileName(string rate)
		{
			switch (rate)
			{
				case "2013":
					return new File(..., "abc", "def");
				case "2014":
					return new File(..., "pqr", "xyz");
				default:
					throw new ArgumentException(String.Format("Unexpected rate '{0}'.", rate)); // Or, simply return null
			}
		}
	}
