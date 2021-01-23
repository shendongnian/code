	static void Main(string[] main)
	{
			var samples = @"<Sampels>
							<Sampel Attribute1='a' Attribute2='b' Attribute3='3' Attribute4='d' />
							<Sampel Attribute1='asdf' Attribute2='b' Attribute3='3' Attribute4='name' />
							<Sampel Attribute1='' Attribute2='' Attribute3='66' Attribute4='attri' />
							<Sampel Attribute1='' Attribute2='b' Attribute3='' Attribute4='sampelname' />
							</Sampels>";
			dynamic Sampels = DynamicXml.Parse(samples);
			foreach(var sample1 in Sampels.Sampel)
			{
				Console.WriteLine(sample1.Attribute4);
			}
	
	}
	
	// using http://stackoverflow.com/questions/13704752/deserialize-xml-to-object-using-dynamic
	public class DynamicXml : System.Dynamic.DynamicObject
	{
		XElement _root;
		private DynamicXml(XElement root)
		{
			_root = root;
		}
	
		public static DynamicXml Parse(string xmlString)
		{
			return new DynamicXml(XDocument.Parse(xmlString).Root);
		}
	
		public static DynamicXml Load(string filename)
		{
			return new DynamicXml(XDocument.Load(filename).Root);
		}
	
		public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
		{
			result = null;
	
			var att = _root.Attribute(binder.Name);
			if (att != null)
			{
				result = att.Value;
				return true;
			}
	
			var nodes = _root.Elements(binder.Name);
			if (nodes.Count() > 1)
			{
				result = nodes.Select(n => new DynamicXml(n)).ToList();
				return true;
			}
	
			var node = _root.Element(binder.Name);
			if (node != null)
			{
				if (node.HasElements)
				{
					result = new DynamicXml(node);
				}
				else
				{
					result = node.Value;
				}
				return true;
			}
	
			return true;
		}
	}
