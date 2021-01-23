	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Xml;
	using System.Xml.Serialization;
	using System.Xml.XPath;
	using System.Xml.Xsl;
	namespace ConsoleApplication2
	{
		class Program
		{
			static void Main(string[] args)
			{
				GetBasicData getBasicData = new GetBasicData();
				getBasicData.CONO = "1";
				getBasicData.CUNO = "201702";
				XPathDocument requestXPathDocument;
				if (SerializeIntoRequestXPathDocument(getBasicData, out requestXPathDocument))
				{
					XmlDocument requestXmlDocument;
					if (CreateRequestXMLDocument(requestXPathDocument, @"Z:\Darice\M3 SOAP\GetBasicData.xsl", out requestXmlDocument))
					{
						XmlDocument responseXmlDocument;
						if (ExecuteRequestSoap(requestXmlDocument, out responseXmlDocument))
						{
							MemoryStream unwrappedMemoryStream;
							if (UnwrapSoapResponseXmlDocumentIntoMemoryStream(responseXmlDocument, out unwrappedMemoryStream))
							{
								GetBasicDataResponse getBasicDataResponse;
								if (!DeserializeResponseMemoryStream(unwrappedMemoryStream, out getBasicDataResponse))
								{
									Debug.WriteLine("FAIL");
								}
							}
						}
					}
				}
				Console.ReadLine();
			}
			//STATIC FUNCTIONS
			private static Boolean CreateRequestXMLDocument(XPathDocument xPathDocument, String xslPath, out XmlDocument xmlDocument)
			{
				try
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (StreamWriter streamWriter = new StreamWriter(memoryStream))
						{
							XmlWriter xmlWriter = XmlWriter.Create(streamWriter);
							XsltSettings xsltSettings = new XsltSettings();
							xsltSettings.EnableScript = true;
							XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
							xslCompiledTransform.Load(xslPath, xsltSettings, null);
							xslCompiledTransform.Transform(xPathDocument, xmlWriter);
							memoryStream.Position = 0;
							using (StreamReader streamReader = new StreamReader(memoryStream))
							{
								XmlReader xmlReader = XmlReader.Create(streamReader);
								xmlDocument = new XmlDocument();
								xmlDocument.Load(xmlReader);
							}
						}
					}
				}
				catch (Exception exception)
				{
					Debug.WriteLine(exception);
					xmlDocument = null;
					return false;
				}
				return true;
			}
			private static Boolean DeserializeResponseMemoryStream<T>(MemoryStream memoryStream, out T xmlObject)
			{
				try
				{
					using (StreamReader streamReader = new StreamReader(memoryStream))
					{
						XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
						using (XmlReader xmlReader = XmlReader.Create(streamReader))
						{
							xmlObject = (T)xmlSerializer.Deserialize(xmlReader);
						}
					}
				}
				catch (Exception exception)
				{
					Debug.WriteLine(exception);
					xmlObject = default(T);
					return false;
				}
				return true;
			}
			private static Boolean ExecuteRequestSoap(XmlDocument requestXmlDocument, out XmlDocument responseXmlDocument)
			{
				try
				{
					Byte[] byteArray = UTF8Encoding.UTF8.GetBytes(requestXmlDocument.OuterXml);
					WebRequest webRequest = WebRequest.Create(Properties.Resources.SoapServerAddress);
					webRequest.ContentLength = byteArray.Length;
					webRequest.ContentType = @"text/xml; charset=utf-8";
					webRequest.Headers.Add("SOAPAction", @"http://schemas.xmlsoap.org/soap/envelope/");
					webRequest.Method = "POST";
					
					using (Stream requestStream = webRequest.GetRequestStream())
					{
						requestStream.Write(byteArray, 0, byteArray.Length);
						using (WebResponse webResponse = webRequest.GetResponse())
						{
							using (Stream responseStream = webResponse.GetResponseStream())
							{
								using (StreamReader streamReader = new StreamReader(responseStream))
								{
									responseXmlDocument = new XmlDocument();
									responseXmlDocument.LoadXml(streamReader.ReadToEnd());
								}
							}
						}
					}
				}
				catch (Exception exception)
				{
					Debug.WriteLine(exception);
					responseXmlDocument = null;
					return false;
				}
				return true;
			}
			private static Boolean SerializeIntoRequestXPathDocument<T>(T dataObject, out XPathDocument xPathDocument)
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (StreamWriter streamWriter = new StreamWriter(memoryStream))
						{
							xmlSerializer.Serialize(streamWriter, dataObject);
							memoryStream.Position = 0;
							using (StreamReader streamReader = new StreamReader(memoryStream))
							{
								memoryStream.Position = 0;
								xPathDocument = new XPathDocument(streamReader);
							}
						}
					}
				}
				catch (Exception exception)
				{
					Debug.WriteLine(exception);
					xPathDocument = null;
					return false;
				}
				return true;
			}
			private static Boolean UnwrapSoapResponseXmlDocumentIntoMemoryStream(XmlDocument responseXmlDocument, out MemoryStream memoryStream)
			{
				try
				{
					XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(responseXmlDocument.NameTable);
					xmlNamespaceManager.AddNamespace("tns", "CRS610MI");
					xmlNamespaceManager.AddNamespace("SOAP", @"http://schemas.xmlsoap.org/soap/envelope/");
					XmlNode xmlNode = responseXmlDocument.SelectSingleNode(@"/SOAP:Envelope/SOAP:Body/tns:GetBasicDataResponse", xmlNamespaceManager);
					
					memoryStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(xmlNode.OuterXml));
				}
				catch (Exception exception)
				{
					Debug.WriteLine(exception);
					memoryStream = null;
					return false;
				}
				return true;
			}
		}
	}
