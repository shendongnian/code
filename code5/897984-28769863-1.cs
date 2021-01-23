    private Task<Microsoft.OData.Client.DataServiceResponse> SaveAsych(Microsoft.OData.Client.SaveChangesOptions options)
        {
            return Task.Factory.FromAsync<Microsoft.OData.Client.DataServiceResponse>(
                 (asyncCallback, asyncState) =>
                     c.BeginSaveChanges(options, asyncCallback, asyncState),
                 (asyncResult) =>
                     c.EndSaveChanges(asyncResult), null);
        }
