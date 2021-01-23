		public static void UpdateXmlSignature(string filename)
		{
			// Load the target xml, the xml file with the certificate
			var doc = XDocument.Load(filename);
			var cert = doc.XPathSelectElement("//X509Data/X509Certificate");
			if (cert != null)
			{
				var updatedValue = rtrim(chunk_split(base64_encode(cert.Value), 76));
				cert.Value = updatedValue;
			}
		
			// Overwrite the old file
			doc.Save(filename);
		}
