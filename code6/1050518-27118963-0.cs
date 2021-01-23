	using (XmlReader reader = XmlReader.Create(new StringReader(strxml)))
	{
		while (reader.Read())
		{
			if (reader.IsStartElement())
			{
				switch (reader.Name)
				{
					case "Row":                     
						if (!Flag)
						{
							reader.ReadToFollowing("TERM-ID");
							reader.Read();
							string strTERMID = reader.ReadContentAsString();						 
							if (strTERMID == strTerminalId)
							{
								reader.ReadToFollowing("USER-ID");									
								reader.Read();
								strUserName = reader.ReadContentAsString();
								Flag = true;
							}
						}
						break;
				}
			}
		}
	}
