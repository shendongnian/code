	// load the xml document
	var xml = XDocument.Load(@"d:\input.xml");
	// find the signature node
	var signature = xml.Root.Elements().FirstOrDefault(r => r.Value.Contains("Signature"));
	if (signature != null)
	{
		// get the namespace of the signature node in order to search for the sub nodes
		var ns = signature.GetDefaultNamespace();
		// find the certificate node
		var certificate = signature.Descendants(ns + "X509Certificate").FirstOrDefault();
		if (certificate != null)
		{
			// take the value
			Console.WriteLine(certificate.Value);
		}
	}
