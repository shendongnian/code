    private static void Row_Changed(object sender, DataRowChangeEventArgs e)
    {
        try
        {
            MySqlCommandBuilder cmdb = new MySqlCommandBuilder(sda);
            sda.Update(dbDataset);                
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void Row_Deleted(object sender, DataRowChangeEventArgs e)
    {
        try
        {
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
            da.Update(dt);                
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
