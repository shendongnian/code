    		// Set the Access Token
			Token token = new Token();
			token.AccessToken = "YOUR_TOKEN";
			// Use the Smartsheet Builder to create a Smartsheet
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(token.AccessToken).Build();
			// Gets just a list of sheets (not the actual data in the sheet)
			IList<Sheet> homeSheets = smartsheet.Sheets().ListSheets();
			foreach (Sheet tmpSheet in homeSheets)
			{
				Console.WriteLine("========== New Sheet: " + tmpSheet.Name);
				// Get the sheet with the data
				Sheet sheet = smartsheet.Sheets().GetSheet((long)tmpSheet.ID, new ObjectInclusion[] { ObjectInclusion.DATA, ObjectInclusion.COLUMNS });
				int rowCount = 0;
				foreach (Row tmpRow in sheet.Rows)
				{
					Console.Write(rowCount++ + ": ");
					foreach (Cell tmpCell in tmpRow.Cells)
					{
						Console.Write(tmpCell.Value + "|");
					}
					Console.WriteLine();
				}
			}
