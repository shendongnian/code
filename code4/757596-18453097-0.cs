    class Program
    {
    	static void Main(string[] args)
    	{
    		var mypath = @"c:\my\search\directory";
    		string[] files = Directory.GetFiles(mypath, "*abc.xls", SearchOption.AllDirectories);
    
    		foreach (var file in files)
    		{
    			Find(Path.Combine(mypath,file));
    		}
    	}
    
    	private static void Find(string path)
    	{
    		object missing = null;
    		Excel.Range currentFind = null;
    		Excel.Range firstFind = null;
    		var app = new Excel.Application();
    		app.Visible = true;
    		Excel.Workbook workbook = app.Workbooks.Open(path, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    		var worksheet = workbook.Sheets[1];
    
    
    		Excel.Range foundNames = worksheet.Range["A1", "B3"];
    		// You should specify all these parameters every time you call this method, 
    		// since they can be overridden in the user interface. 
    		currentFind = foundNames.Find("Peter, Paul, Mary", LookIn: XlFindLookIn.xlValues, LookAt: XlLookAt.xlPart);
    		
    		currentFind.Replace(What:"Peter, Paul, Mary", Replacement:"Peter, John, Susan");
    
    		workbook.Save();
    	}
    }
