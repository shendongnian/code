    internal void GetYourData()
	{
		//... code to get the relevant Workbook and relevant/new Excel Application
		Tuple<string, string> pupil;
		string searchTerm = "ABC";
		//Get the cell of the match
		Range match = FindFirstOccurrenceInWorkbook(workbook, searchTerm);
		if (match != null)
		{
			//Do whatever - per your data structure, it is probably easiest to just use .Offset(row, column) property
			pupil = new Tuple<string, string>((string)match.Offset(0, -1).Value, (string)match.Offset(0, 1).Value);
		}
		//... code to do whatever with your results
	}
	internal static Range FindFirstOccurrenceInWorkbook(Workbook workbook, string searchTerm)
	{
		if (workbook == null) throw new ArgumentNullException("workbook");
		if (searchTerm == null) throw new ArgumentNullException("searchTerm");
		Sheets wss = workbook.Worksheets;
		Range match = null;
		foreach (Worksheet ws in wss)
		{
			Range cells = ws.Cells;
			//Add more args as needed - this is just an example
			match = cells.Find(
					what: searchTerm,
					after: Type.Missing,
					lookIn: XlFindLookIn.xlFormulas,
					lookAt: XlLookAt.xlPart);
			System.Runtime.InteropServices.Marshal.ReleaseComObject(cells);
			System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
			if (match != null)
			{
				break;
			}
		}
		System.Runtime.InteropServices.Marshal.ReleaseComObject(wss);
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		return match;
	}
