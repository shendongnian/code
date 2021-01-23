	public class Profiles
	{
		[XmlElement(ElementName="Profile")]
		public List<Profile> Profile { get; set; }
	}
	
	public class Profile
	{
		[XmlArray(ElementName="Buttons")]
		public List<Button> Buttons { get; set; }
		[XmlAttribute]
		public String Name;
	}
	
	public class Button
	{
		[XmlAttribute]
		public String Pressed { get; set; }
		[XmlAttribute]
		public String Released;
	}
