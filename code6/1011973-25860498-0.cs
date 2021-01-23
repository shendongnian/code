    CsvContext cc = new CsvContext();
    string outputFileName = string.Format("D:\\Dashboard.csv", DateTime.Now);
    cc.Write(categoryList, outputFileName);  
    Response.Clear();
    Response.ContentType = "text/csv"; //or "application/csv" 
    Response.AddHeader("Content-disposition", "attachment; filename=\"sample.csv" + "\"");
    Response.WriteFile(outputFileName);
    Response.Flush();
    Response.End();
