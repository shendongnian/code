    if (data.Tables["Discounts"].GetChanges(System.Data.DataRowState.Deleted) != null)
    {
        detailsBindingSource.EndEdit();
        System.Data.DataTable DeletedChildRecords =
            data.Tables["Discounts"].GetChanges(System.Data.DataRowState.Deleted);
        try
        {
            if (DeletedChildRecords != null)
            {
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(detailsDataAdapter);
                detailsDataAdapter.Update(data.Tables["Discounts"].Select(null, null, DataViewRowState.Deleted));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            if (DeletedChildRecords != null)
            {
                DeletedChildRecords.Dispose();
            }
        }
    }
    if (data.Tables["Customers"].GetChanges(System.Data.DataRowState.Added) != null || data.Tables["Customers"].GetChanges(System.Data.DataRowState.Modified) != null ||
        data.Tables["Customers"].GetChanges(System.Data.DataRowState.Deleted) != null)
    {
        masterBindingSource.EndEdit();
        try
        {
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(masterDataAdapter);
            masterDataAdapter.Update(data.Tables["Customers"].Select(null, null, DataViewRowState.Deleted));
            masterDataAdapter.Update(data.Tables["Customers"].Select(null, null, DataViewRowState.ModifiedCurrent));
            masterDataAdapter.Update(data.Tables["Customers"].Select(null, null, DataViewRowState.Added));
        }
        catch (System.Exception err)
        {
            MessageBox.Show(err.ToString());                        
        }
    }
    if (data.Tables["Discounts"].GetChanges(System.Data.DataRowState.Added) != null || data.Tables["Discounts"].GetChanges(System.Data.DataRowState.Modified) != null)
    {
        detailsBindingSource.EndEdit();
        System.Data.DataTable NewChildRecords =
            data.Tables["Discounts"].GetChanges(System.Data.DataRowState.Added);
        System.Data.DataTable ModifiedChildRecords =
            data.Tables["Discounts"].GetChanges(System.Data.DataRowState.Modified);
        try
        {
            if (ModifiedChildRecords != null)
            {
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(detailsDataAdapter);
                detailsDataAdapter.Update(data.Tables["Discounts"].Select(null, null, DataViewRowState.ModifiedCurrent));
            }
            if (NewChildRecords != null)
            {
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(detailsDataAdapter);
                detailsDataAdapter.Update(data.Tables["Discounts"].Select(null, null, DataViewRowState.Added));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            if (NewChildRecords != null)
            {
                NewChildRecords.Dispose();
            }
            if (ModifiedChildRecords != null)
            {
                ModifiedChildRecords.Dispose();
            }
        }
    }
