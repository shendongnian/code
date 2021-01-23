    private void AddItemsToListView(List<Cable> cables)
    {
        var items = GetCableNaviagations(cables)
                       .Select(CreateListViewItem)                       
                       .ToArray();
        
        listView1.Items.AddRange(items);
    }
    // consider to do data retrieving in background thread
    private IEnumerable<Cable> GetCableNaviagations(IEnumerable<Cable> cables)
    {
       var arg = "CableProperty,CableProperty.Catalogue,CableProperty.CableApplication,User";
       using (CableServiceClient client = new CableServiceClient())
       {
            foreach(var cable in cables)
            {
               var criteria = new SearchElement[] { 
                  new SearchElement { 
                       Comparison = "=", 
                       FieldName = "Id", 
                       FieldValue = cable.Id, 
                       LogicalOperator = ""      
                  } };
   
               yield return client.GetCables(criteria, null, arg).SingleOrDefault();
            }
            client.Close();
        }
    }
