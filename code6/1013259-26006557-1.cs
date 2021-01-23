    public static DataSet GetDataFromCSV(this DataSet ds, string data_table_name,string csv_file_path)
        {
             string strLine;
             string[] strArray;
             char[] charArray = new char[] {','};
             DataTable dt = ds.Tables.Add(data_table_name);
             FileStream aFile = new FileStream(csv_file_path,FileMode.Open);
             StreamReader sr = new StreamReader(aFile);
             strLine = sr.ReadLine();
             strArray = strLine.Split(charArray);
         
             for(int x=0;x<=strArray.GetUpperBound(0);x++) 
             {
                dt.Columns.Add(strArray[x].Trim());
             }
         
             strLine = sr.ReadLine();
             while(strLine != null) {
                strArray = strLine.Split(charArray);
                DataRow dr = dt.NewRow();
                for(int i=0;i<=strArray.GetUpperBound(0);i++) 
                {
                   dr[i] = strArray[i].Trim();
                }
                dt.Rows.Add(dr);
                strLine = sr.ReadLine();
             }
             sr.Close();
             return ds;
        }
