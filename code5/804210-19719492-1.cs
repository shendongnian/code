    using (var messageReader = new ODataMessageReader(responseMessage, readerSettings, model))
    {
       var feedReader = messageReader.CreateODataFeedReader(entityType, entitySet);
       while (feedReader.Read())
       {
           switch(feedReader.State)
           {
              case ODataReaderState.EntryEnd:
              {
                 ODataEntry entry = (ODataEntry) feedReader.Item;
                 // access entry.Properties, etc.
                 break;
              }
           }
       }
    }
