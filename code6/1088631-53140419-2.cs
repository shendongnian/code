    // Print message on Console
    Console.WriteLine("Reading XLSB file in C# using Aspose.Cells API.");
    Console.WriteLine("----------------------------------------------");
    
    // Directory path of input and output files.
    string dirPath = "D:/Download/";
    
    // Load your source XLSB file inside the Aspose.Cells Workbook object.
    Workbook wb = new Workbook(dirPath + "Source.xlsb");
    
    // Access first worksheet.
    Worksheet ws = wb.Worksheets[0];
    
    // Access cells enumarator
    System.Collections.IEnumerator iEnum = ws.Cells.GetEnumerator();
    
    // Print the cells data in while loop on console.
    while(iEnum.MoveNext())
    {
    	Cell cell = (Cell)iEnum.Current;
    	Console.WriteLine(cell.Value);
    }
