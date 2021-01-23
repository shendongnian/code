    var tmpResult = from mdv in allMetaDataValues
                      where mdv.Metadata.InputType == MetadataInputType.String && mdv.Metadata.ShowInFilter && !mdv.Metadata.IsHidden && !string.IsNullOrEmpty(mdv.ValueString)
                      group mdv by new
                      {
                        mdv.ValueString,
                        mdv.Metadata
                      } into g
                      let first = g.Take(1)
                      select new
                      {
                        MetadataTitle = g.Key.Metadata.Title,
                        MetadataID = g.Key.Metadata.ID,
                        CollectionColor = g.Key.Metadata.Collection.Color,
                        CollectionID = g.Key.Metadata.Collection.ID,
    
                        MetadataValueCount = 0,
                        MetadataValueTitle = g.Key.ValueString,
                        MetadataValueID = first.ID
                      };
