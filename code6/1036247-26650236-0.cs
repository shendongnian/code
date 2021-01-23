    using System.IO;
    using OfficeOpenXml;
    class Program
    {
    	static void Main(string[] args)
    	{
    	    string csvFileName = @"FL_insurance_sample.csv";
    	    string excelFileName = @"FL_insurance_sample.xls";
    
    	    string worksheetsName = "TEST";
    
    	    bool firstRowIsHeader = false;
    
    	    var format = new ExcelTextFormat();
    	    format.Delimiter = ',';
    	    format.EOL = "\r";              // DEFAULT IS "\r\n";
    	    // format.TextQualifier = '"';
    
    	    using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFileName)))
    	    {
    		    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
    		    worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFileName), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
    		    package.Save();
    	    }
    
    	    Console.WriteLine("Finished!");
    	    Console.ReadLine();
    	}
    }
