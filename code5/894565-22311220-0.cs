    FileStream fs = null;
    Microsoft.Office.Interop.Excel.Application app = null;
    try
    {
    	app = new Microsoft.Office.Interop.Excel.Application();
    	app.Workbooks.Add("");
    
    	Warning[] warnings;
    	string[] streamids;
    	string mimeType;
    	string encoding;
    	string extension;
    	
    	// Uses a string of comma separated ints to determine which reports to print
    	foreach (string indexChecked in Properties.Settings.Default.PrintAllReports.Split(','))
    	{
    		// Create temp file
    		fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
    		byte[] bytes = this.reports[Convert.ToInt32(indexChecked)].LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out extension, out streamids, out warnings);
    		fs.Write(bytes, 0, bytes.Length);
    		fs.Close();
    		fs = null;
    		// Add copy of workbook
    		app.Workbooks.Add(saveFileDialog1.FileName);
    	}
    
    	// Process each workbook and combine
    	// http://stackoverflow.com/questions/7376964/how-to-merge-two-excel-workbook-into-one-workbook-in-c
    	for (int i = app.Workbooks.Count; i >= 2; i--)
    	{
    		int count = app.Workbooks[i].Worksheets.Count;
    		app.Workbooks[i].Activate();
    
    		for (int j = 1; j <= count; j++)
    		{
    			Microsoft.Office.Interop.Excel._Worksheet ws = (Microsoft.Office.Interop.Excel._Worksheet)app.Workbooks[i].Worksheets[j];
    			ws.Select(Type.Missing);
    			ws.Cells.Select();
    
    			Microsoft.Office.Interop.Excel.Range sel = (Microsoft.Office.Interop.Excel.Range)app.Selection;
    			sel.Copy(Type.Missing);
    
    			Microsoft.Office.Interop.Excel._Worksheet sheet = (Microsoft.Office.Interop.Excel._Worksheet)app.Workbooks[1].Worksheets.Add(
    				Type.Missing, Type.Missing, Type.Missing, Type.Missing
    			);
    
    			sheet.Paste(Type.Missing, Type.Missing);
    			sheet.Name = ws.Name;
    			Clipboard.Clear();
    			app.Workbooks[i].Close();
    		}
    	}
    
    	// Remove it if it exists, we already asked once
    	if (System.IO.File.Exists(saveFileDialog1.FileName))
    	{
    		try
    		{
    			System.IO.File.Delete(saveFileDialog1.FileName);
    		}
    		catch (System.IO.IOException)
    		{
    			// It will ask and then overwrite in the next step if the delete failed
    		}
    	}
    	app.Workbooks[1].SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges);
    	app.Workbooks[1].Close();
    	app = null;
    }
    catch (IOException)
    {
    	// uses a wrapper method
    	this.showErrorDialog("Report Generator cannot access the file '" + saveFileDialog1.FileName + "'. There are several possible reasons:\n\n\u2022 The file name or path does not exist.\n\u2022 The file is being used by another program.");
    }
    finally
    {
    	if (fs != null)
    	{
    		fs.Close();
    	}
    	if (app != null)
    	{
    		app.Workbooks.Close();
    	}
    }
