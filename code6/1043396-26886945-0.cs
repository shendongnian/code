    RetrieveMultipleRequest retrieve = new RetrieveMultipleRequest();
    retrieve.Query = query;
    retrieve.ReturnDynamicEntities = true;
     
    retrieved = (RetrieveMultipleResponse)Service.Execute(retrieve);
    foreach(var dynEntity in retrieved.BusinessEntityCollection)
    {
        foreach (var prop in dynEntity.Properties)
        {
            lstRecordDetails.Items.Add(string.Format("{0}:{1}", prop.Name, prop.Value);
        }
    }
