	using System;
	using System.IO;
	using System.Xml;
	using System.Xml.Serialization;
	namespace XmlDeSerialize
	{
		[XmlRoot("Quote")]
		public class Quote
		{
			[XmlElement("Insurance")]
			public InsuranceDetails InsDetails { get; set; }
			[XmlElement("Payment")]
			public PaymentDetails PayDetails { get; set; }
		}
		public class InsuranceDetails
		{
			[XmlElement(ElementName = "Details1")]
			public string Details1 { get; set; }
		}
		public class PaymentDetails
		{
			[XmlElement(ElementName = "Details1")]
			public string Details1 { get; set; }
		}
		class Program
		{
			static void Main(string[] args)
			{
				var qin = new Quote
				{
					InsDetails = new InsuranceDetails { Details1 = "insurance details text" },
					PayDetails = new PaymentDetails { Details1 = "payment details text" },
				};
				string xml;
				using (var stream = new MemoryStream())
				{
					var serializer = new XmlSerializer(typeof(Quote));
					serializer.Serialize(stream, qin);
					stream.Position = 0;
					using (var sr = new StreamReader(stream))
					{
						xml = sr.ReadToEnd();
					}
				}
				Quote qout;
				using (TextReader read = new StringReader(xml))
				{
					var deserializer = new XmlSerializer(typeof(Quote));
					var obj = deserializer.Deserialize(read);
					qout = (Quote)obj;
				}
				Console.WriteLine("InsDetails.Details1='{0}'", qout.InsDetails.Details1);
				Console.WriteLine("PayDetails.Details1='{0}'", qout.PayDetails.Details1);
			}
		}
	}
