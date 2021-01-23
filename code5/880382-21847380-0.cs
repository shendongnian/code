    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            main delete = new main();
            DataTable dt = GridView1.DataSource as DataTatable;
            sQLcONN.Open();
            string Query = "delete from shoppingcart where shoppingcart.with_puja = '" + Convert.ToInt32(dt.Rows[e.RowIndex]["nameOfKey"]).ToString() + "'";
            delete.deleteData(Query);
            Bindgrid();
            sQLcONN.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
    }
