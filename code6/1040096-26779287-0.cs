    string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data
    Source={0};Extended Properties='Excel 8.0;HRD=YES;IMEX=1'", 
    Server.MapPath(@"~\DownloadedExcelFilesOp4\myfile" + fileExt));// + "\\" +
    FileUploadControl.PostedFile.FileName.ToString());
    using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
    {
       OleDbCommand command = new OleDbCommand(("Select [Demo1] ,[Demo2]  FROM [Sheet1$]"), 
       connection);
       connection.Open();
       using (DbDataReader dr = command.ExecuteReader())
       {
       }
    }
