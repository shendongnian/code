     Item bucketItem = //Code to get $Company Node as a Sitecore Item
      //Probably Sitecore.Context.Database.GetItem("Guid for $Company Node")
     using (var searchContext = ContentSearchManager.GetIndex(bucketItem as      IIndexable).CreateSearchContext())
      {
         try
         {
              var result = searchContext.GetQueryable<SearchResultItem>().Where(x => x.Name == itemName).FirstOrDefault();
                 if (result != null)
                     Context.Item = result.GetItem();
         }
         catch (Exception)
         {
             //Do something
         }
      }
