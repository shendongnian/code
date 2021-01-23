    private void Create_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList flds = new ArrayList();
            flds.Add("test1");
            flds.Add("test2");
    
            var columnDef = string.Join(",", flds.Select(fld => string.Format("[{0}] [nvarchar](100) NULL", fld)));
    
            conn.Open();
            cmd = new SqlCommand("CREATE TABLE [" + Tbname.Text + "] ([id] INT NULL, [name] CHAR (20) NULL, " + columnDef + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
