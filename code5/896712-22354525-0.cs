    [ChangeInterceptor("Customers")] // table to query intercept
    public void WindowsServiceChange(Customer customerEntity, UpdateOperations operations)
    {            
            // make sure following colums are not changed
            if (this.CurrentDataSource.Entry(customerEntity).Property("Password").IsModified)
            {
                // client attempted to update a column he was not supposed to update
                throw new DataServiceException(400, "Access to update column denied");
            }
            // else do nothing
    }
