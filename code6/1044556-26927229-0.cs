       from mdv in allMetaDataValues.Include("Metadata").Include("Metadata.Collection")
       where mdv.Metadata.InputType == MetadataInputType.String && 
             mdv.Metadata.ShowInFilter && 
    		 !mdv.Metadata.IsHidden && 
    		 !string.IsNullOrEmpty(mdv.ValueString)
       group mdv by new
       {
         MetadataID = mdv.Metadata.ID,
    	 CollectionID = mdv.Metadata.Collection.ID,
    	 mdv.Metadata.Title,
    	 mdv.Metadata.Collection.Color,
         mdv.ValueString
       } into g
       let first = g.FirstOrDefault()
       select new
       {
         MetadataTitle = g.Key.MetadataID,
         MetadataID = g.Key.CollectionID,
         CollectionColor = g.Key.Title,
         CollectionID = g.Key.Color,
         MetadataValueCount = 0,
         MetadataValueTitle = g.Key.ValueString,
         MetadataValueID = first.ID
       }
