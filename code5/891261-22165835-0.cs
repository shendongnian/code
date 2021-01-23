    public class Demo
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    	public string Status { get; set; }
    }
	string pathToExcelFile = @"path\to\file.xslx";  
	string sheetName = "Tabelle1";
	
	var excelFile = new ExcelQueryFactory(pathToExcelFile);
        //strongly type the result
	Demo rowToUpdate = (from xc in excelFile.Worksheet<Demo>(sheetName) 
					   where xc.ID == 1
					   select xc).FirstOrDefault();
        //update retrieved record
	rowToUpdate.Status = "Active";
        //output in linqpad
	rowToUpdate.Dump();
        //no submitchanges or save method available :(
