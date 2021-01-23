		[XmlRoot("Sample")]
		public class SampleDto
		{
			private string name;
			//more fields here
			[XmlElement("Name")]
			public string Name
			{
				get { return name; }
				set { name = value; }
			}
			//more properties here
		}
