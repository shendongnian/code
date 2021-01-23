	var xmlstring = @"<Products>
					<Equity>
					<servers>
						<serverEQ>server1</serverEQ>
						<serverEQ>server2</serverEQ>
						<serverEQ>server3</serverEQ>
					</servers>
					<sitesE>
						<sitesEQ sitePathEQ=""\Logs\W3SVC1""><nameEQ>SystemAdmin Site</nameEQ></sitesEQ>
						<sitesEQ sitePathEQ=""\Logs\W3SVC3""><nameEQ>Direct Access Site</nameEQ></sitesEQ>
						<sitesEQ sitePathEQ=""\Logs\W3SVC4""><nameEQ>Redirect Site</nameEQ></sitesEQ>
						<sitesEQ sitePathEQ=""\Logs\W3SVC5""><nameEQ>Download Site</nameEQ></sitesEQ>
					</sitesE>
					</Equity>
					</Products>";
	var xml = XDocument.Parse(xmlstring);
	var node = xml.Descendants("sitesEQ").Where(d => d.Descendants("nameEQ").Any(n => n.Value == "Redirect Site"));
	var attribute = node.Attributes().FirstOrDefault();
	var logValue = attribute.Value;
