    StreamWriter CsvfileWriter = null;
    
    private void btnGetSku_Click(object sender, EventArgs e)
        {
        Stopwatch swra = new Stopwatch();
        swra.Start();
        
        if(CsvfileWriter == null)
           CsvfileWriter = new StreamWriter(@"D:\testfile.csv");
        string connectionString = null;
        SqlConnection cnn;
        connectionString = "Data Source=My-PC-Name;Initial Catalog=MyDB;User            
        cnn = new SqlConnection(connectionString);
         ID=Name;Password=********";
        cnn.Open();
        SqlCommand cmd = new SqlCommand(textBox1.Text, cnn);
        cmd.CommandText = textBox1.Text;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 2000;
        using (cnn)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            // Don't use using here. This disposes the streams
            //using (CsvfileWriter)
            {
                //For getting the Table Headers
                DataTable Tablecolumns = new DataTable();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    Tablecolumns.Columns.Add(rdr.GetName(i));
                }
                CsvfileWriter.WriteLine(string.Join(",",  
               Tablecolumns.Columns.Cast<DataColumn>().Select(csvfile =>   
               csvfile.ColumnName)));
                while (rdr.Read())
                {
                    label1.Text = rdr["SKU"].ToString() + " " +    
                       rdr["SKUCode"].ToString();
                    CsvfileWriter.WriteLine(rdr["SKU"].ToString() + "," + 
               rdr["SKUCode"].ToString() + "," + 
                   rdr["Compliance_Curr"].ToString() + "," + 
                  rdr["Compliance_Prev"].ToString() + "," + 
             rdr["Difference"].ToString() + "," + 
            rdr["TotalSales_Curr"].ToString() + ",");
                }
                cnn.Close();
            }
        }
        swra.Stop();
        Console.WriteLine(swra.ElapsedMilliseconds);
    }
