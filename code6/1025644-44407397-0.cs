    private void test(DataTable dt1) {
    
        string csv = string.Empty;
    
        foreach (DataColumn column in dt1.Columns)
        {
            //Add the Header row for CSV file.
            csv += column.ColumnName + ',';
        }
    
        //Add new line.
        csv += "\r\n";
    
        foreach (DataRow row in dt1.Rows)
        {
            foreach (DataColumn column in dt1.Columns)
            {
                //Add the Data rows.
                csv += row[column.ColumnName].ToString().Replace(",", ";") +',';
            }
    
            //Add new line.
            csv += "\r\n";
        }
    
        string datetime = Convert.ToString(DateTime.Today.ToString("dd-MM-yyyy")).Trim();
        string filepath = "C:\\Users\\Prateek\\Desktop\\MMR New  27-07 -\\Domestic\\";
        string filename= @"BILLING_BOOK_NO" + "_4005" + "_"+datetime+".CSV";
        string combinepath = filepath + filename;          
       System.IO.File.WriteAllText(combinepath,csv);
    }`
