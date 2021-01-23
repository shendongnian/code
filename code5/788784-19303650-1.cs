    private void Create_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList flds = new ArrayList();
            flds.Add("test1");
            flds.Add("test2");
            conn.Open();
	Foreach Item in flds
	{
            cmd = new SqlCommand("CREATE TABLE [" + Tbname.Text + "] ([id] INT NULL, [name] CHAR (20) NULL, [" + Item + "] CHAR (20) NULL)", conn);
            cmd.ExecuteNonQuery();
	}
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
