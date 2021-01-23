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
							.Element("entities")
							.Elements("entity")
							.ToDictionary(
								x => x.Element("name").Value,
								x => (decimal)x.Element("adif"));
				}
			}
		}
	}
