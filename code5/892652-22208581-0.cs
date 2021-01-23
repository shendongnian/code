    FileInfo file = new FileInfo(path);
    if (file.Exists)
    {
        try
        {
            _package = new ExcelPackage(file);
            _sheet = _package.Workbook.Worksheets.First();
        }
        catch (IOException)
        {
            SendEmail.OkMail("Spreadsheet is currently in use. Please close and try again.");
            
            //Exit program
            Environment.Exit(0);
        }
    }
    else
    {
        //Notify user and exit program
        SendEmail.OkMail("Cannot find file in requested directory. Please check and try again.");
    
        //Exit program
        Environment.Exit(0);
    }
