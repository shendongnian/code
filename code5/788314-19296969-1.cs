	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	using System.Runtime.Serialization;
	using System.Xml;
	using System.IO;
	using System.Text;
	namespace NamespaceGoesHere
	{
		[DataContract()]
		public class ClassNameGoesHere
		{
			//All your properties go here, for example:
			[DataMember()]
			public string PropertyName { get; set; }
			//Note the use of [DataMember()] and [DataContract()]
			#region "Serialisation"
			public string Serialise()
			{
				System.IO.MemoryStream s = new System.IO.MemoryStream();
				DataContractSerializer x = new DataContractSerializer(typeof(ClassNameGoesHere));
				x.WriteObject(s, this);
				s.Position = 0;
				StreamReader sw = new StreamReader(s);
				string str = null;
				str = sw.ReadToEnd();
				return str;
			}
			public static ClassNameGoesHere DeSerialise(string xmlDocument)
			{
				XmlDocument doc = new XmlDocument();
				DataContractSerializer ser = new DataContractSerializer(typeof(ClassNameGoesHere));
				StringWriter stringWriter = new StringWriter();
				XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
				doc.LoadXml(xmlDocument);
				doc.WriteTo(xmlWriter);
				MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(stringWriter.ToString()));
				stream.Position = 0;
				XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
				return (ClassNameGoesHere)ser.ReadObject(reader, true);
			}
			#endregion
		}
	}
