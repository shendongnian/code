    using (ODataMessageReader messageReader = new ODataMessageReader(message.GetResponse(), new ODataMessageReaderSettings()))
    {
        ODataReader reader = messageReader.CreateODataFeedReader();
        while (reader.Read())
            while (reader.Read())
            {
                switch (reader.State)
                {
                    case ODataReaderState.EntryEnd:
                    {
                        ODataEntry entry = (ODataEntry)reader.Item;
                        var atomMetadata = entry.Properties.ToList(); 
                        break;
                    }
                 }
             }
    }
