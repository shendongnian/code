    using System.IO;
    using System.IO.Packaging;
    using System.Security.Cryptography;
    static string DacPacFingerprint(byte[] dacPacBytes)
    {
    	using (var ms = new MemoryStream(dacPacBytes))
    	using (var package = ZipPackage.Open(ms))
    	{
    		var modelFile = package.GetPart(new Uri("/model.xml", UriKind.Relative));
    		using (var streamReader = new System.IO.StreamReader(modelFile.GetStream()))
    		{
    			var xmlDoc = new XmlDocument() { InnerXml = streamReader.ReadToEnd() };
    			foreach (XmlNode childNode in xmlDoc.DocumentElement.ChildNodes)
    			{
    				if (childNode.Name == "Header")
    				{
                        // skip the Header node as described
    					xmlDoc.DocumentElement.RemoveChild(childNode);
    					break;
    				}
    			}
    			using (var crypto = new SHA512CryptoServiceProvider())
    			{
    				byte[] retVal = crypto.ComputeHash(Encoding.UTF8.GetBytes(xmlDoc.InnerXml));
    				return BitConverter.ToString(retVal).Replace("-", "");// hex string
    			}
    		}
    	}
    }
