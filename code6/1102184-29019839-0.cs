    public void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            
            try
            {
                this.manageOrdersDataSetCustomerTableAdapter.Update(manageOrdersDataSet.Customer);
            }
            catch
            {
                // do something
            } 
    }
