	public class Vehicule
	{
		public string Name { get; set; }
		public Brand Brand { get; set; }
		
		public Vehicule Clone()
		{
			return new Vehicule { Name = this.Name, Brand = new Brand { Name = this.Brand.Name } };
		}
	}
	public class Car : Vehicule
	{
		public string Matriculation { get; set; }
	}
	
	
	
	public class Brand
	{
		public string Name { get; set; }
	}
	public class Renault : Brand
	{
		public string Information { get; set; }
	}
		
	void Main()
	{	
		var car = new Car { Name = "Clio", Matriculation = "XXX-XXX", Brand = new Renault { Name = "Renault", Information = "Contact Infos" } };
		var vehicle = car as Vehicule;
		
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Vehicule));
		
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Encoding = new UnicodeEncoding(false, false),
			Indent = false,
			OmitXmlDeclaration = false
		};
		
		using(StringWriter textWriter = new StringWriter()) {
			using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) {
				serializer.Serialize(xmlWriter, vehicle.Clone());
			}
			textWriter.ToString().Dump();
		}
	}
