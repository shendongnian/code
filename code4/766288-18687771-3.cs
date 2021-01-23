	// block of settings like 
	// <Service>
	//	<Name>Service1</Name>
	//	<Description>Starts the service 1</Description>
	// </Service>
	public class SettingsService
	{
		// will be a node in the XML file
		[XmlElement(ElementName="Name")]
		public string Name { get; set; }
		// will be a node too
		[XmlElement(ElementName="Description")]
		public string Description { get; set; }
	}
	// holds a list of services
	// <Services>
	//	<Service>...</Service>
	//	<Service>...</Service>
	// </Services>
	public class ServicesSettings
	{
		// list of services
		[XmlArray(ElementName="SettingsServices")]
		public List<SettingsService> Services { get; set; }
		// single value!
		[XmlElement(ElementName="SettingsPort")]
		public int PortNumber { get; set; }
	}
	// serializes the objects to XML file
	public void SerializeModels(string filename, ServicesSettings settings)
	{
		var xmls = new XmlSerializer(settings.GetType());
		var writer = new StreamWriter(filename);
		xmls.Serialize(writer, settings);
		writer.Close();
	}
	// retrieves the objects from an XML file
	public ServicesSettings DeserializeModels(string filename)
	{
		var fs = new FileStream(filename, FileMode.Open);
		var xmls = new XmlSerializer(typeof(WindowsServicesControllerSettings));
		return (WindowsServicesControllerSettings) xmls.Deserialize(fs);
	}
