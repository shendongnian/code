	var dict = (Dictionary<string, decimal>)null;
	using (WebClient wc = new WebClient())
	{
		var text = wc.DownloadString(
			"https://secure.clublog.org/cty.php?api=" + API);
		using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
		{
			using (var zip = new GZipStream(stream, CompressionMode.Decompress))
			{
				using (var xmlReader = XmlReader.Create(zip))
				{
					var xd = XDocument.ReadFrom(xmlReader);
					dict =
                    xd
                        .Document
                        .Root
                        .Element(XName.Get("entities", "http://www.clublog.org/cty/v1.0"))
                        .Elements(XName.Get("entity", "http://www.clublog.org/cty/v1.0"))
                        .ToDictionary(
                            x => x.Element(XName.Get("name", "http://www.clublog.org/cty/v1.0")).Value,
                            x => (decimal)x.Element(XName.Get("adif", "http://www.clublog.org/cty/v1.0")));
				}
			}
		}
	}
