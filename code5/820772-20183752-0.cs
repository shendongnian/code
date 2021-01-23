    // Wrapper for our database operation.
    private void PerformDbOperationAndSubmit(Action<DBDataContext> action)
    {
        using (DBDataContext DB = new DBDataContext()) 
        {
            // Invoke our arbitrary action over the data context.
            action(DB);
            DB.SubmitChanges();
            DB.Connection.Close();
        }
    }
    // Object creation (modified for the sake of brevity).
    private void SaveNewLogsheet01Record()
    {
        Logsheet01 Header = new Logsheet01();
            
        // Fill Header properties here.
        PerformDbOperationAndSubmit(dx => dx.Delivery_HeaderRECs.InsertOnSubmit(Header));                    
    }
    private void SaveNewLogsheet02Record()
    {
        Logsheet02 Details = new Logsheet02();
            
        // Fill Details properties here.
        PerformDbOperationAndSubmit(dx => dx.Logsheet0.InsertOnSubmit(Details));                     
    }
