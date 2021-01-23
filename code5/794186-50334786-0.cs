    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.SqlServer.Server;
    private void button_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = dataSet1.Properties.Settings.Default.ConnectionString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.Table";
    
            SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "dbo.Table");
            DataTable dt = ds.Tables["dbo.Table"];
    
            Excel.Application oXL = new Excel.Application();
            Excel.Workbook oWB = oXL.Workbooks.Add();
            Excel.Worksheet oSheet = oWB.ActiveSheet;
            
            //Puts column headers starting in Row 5
            int col = 0, row = 5;
            foreach (DataColumn dc in dt.Columns)
            {
                oXL.Cells[row, ++col] = dc.ColumnName.ToString();
            }
    
            //Fills data starting in row 6
            foreach (DataRow dr in dt.Rows)
            {
                row++;
                col = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    oXL.Cells[row, ++col] = dr[dc.ColumnName];
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error");
        }
    }
