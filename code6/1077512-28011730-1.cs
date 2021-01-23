	[TestMethod]
	public void Multi_Save_Test()
	{
		//http://stackoverflow.com/questions/28007087/how-to-write-to-excel-many-times-using-one-object-of-epplus-in-c-sharp
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		//Wrap the holding stream for auto disposal
		using (var holdingstream = new MemoryStream())
		using (var pack = new ExcelPackage())
		{
			//Create but WITHOUT the FI so it is a memory stream
			var ExSheet = pack.Workbook.Worksheets.Add("Data");
			ExSheet.Cells["A1"].Value = "wer";
			ExSheet.Cells["B1"].Value = "sdf";
			//Do an incremental save to the file and copy the stream before closing - ORDER COUNTS!
			pack.SaveAs(existingFile);
			holdingstream.SetLength(0);
			pack.Stream.Position = 0;
			pack.Stream.CopyTo(holdingstream);
			//*********************************************************
			//reopen the holding stream, make a change, and resave it
			pack.Load(holdingstream);
			ExSheet = pack.Workbook.Worksheets["Data"];
			ExSheet.Cells["A2"].Value = "wer";
			ExSheet.Cells["B2"].Value = "sdf";
			//Another incremental change
			pack.SaveAs(existingFile);
			holdingstream.SetLength(0);
			pack.Stream.Position = 0;
			pack.Stream.CopyTo(holdingstream);
			//*********************************************************
			//reopen the holding stream, make a change, and resave it
			pack.Load(holdingstream);
			ExSheet = pack.Workbook.Worksheets["Data"];
			ExSheet.Cells["A3"].Value = "wer";
			ExSheet.Cells["B3"].Value = "sdf";
			//Another incremental change
			pack.SaveAs(existingFile);
			holdingstream.SetLength(0);
			pack.Stream.Position = 0;
			pack.Stream.CopyTo(holdingstream);
			//*********************************************************
			//reopen the holding stream, make a change, and do a FINAL save
			pack.Load(holdingstream);
			ExSheet = pack.Workbook.Worksheets["Data"];
			ExSheet.Cells["A4"].Value = "wer";
			ExSheet.Cells["B4"].Value = "sdf";
			//All done so only need to save it to the file
			pack.SaveAs(existingFile);
		}
	}
