    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
        
                DataTable dt = GridView1.DataSource as DataTable;
                if(dt.rows.count>0)
                {
                sQLcONN.Open();
                MySqlCommand objcmd = new MySqlCommand("delete   from shoppingcart where with_puja = '" + Convert.ToInt32(dt.Rows[e.RowIndex]["id"]).ToString() + "'", sQLcONN);
                objcmd.ExecuteNonQuery();
                Bindgrid();
                sQLcONN.Close();
            }
            catch (Exception ex)
            {
                 Console.WriteLine("{0} Exception caught.", ex);
            }
