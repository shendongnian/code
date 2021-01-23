    using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(filepath, false))
	{
		WorkbookPart wbPart = spreadSheetDocument.WorkbookPart;
		OpenXmlReader reader = OpenXmlReader.Create(wbPart);
		while (reader.Read())
		{
			if (reader.ElementType == typeof(Sheet))
			{
				Sheet sheet = (Sheet)reader.LoadCurrentElement();
				WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(sheet.Id));
				OpenXmlReader wsReader = OpenXmlReader.Create(wsPart);
				while (wsReader.Read())
				{
					if(wsReader.ElementType == typeof(Worksheet))
					{
						Worksheet wsPartXml = (Worksheet)wsReader.LoadCurrentElement();
						Console.WriteLine(wsPartXml.OuterXml + "\n");
					}
				}
			}
		}
		Console.ReadKey();
	}
