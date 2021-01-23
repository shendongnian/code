    protected ClientResult<Stream> OpenFileFromListItemAsStream(ClientContext context, string libraryTitle, string filename)
        {
            //source list and list item
            var sourceList = context.Web.Lists.GetByTitle(libraryTitle);
            var sourceListItems = sourceList.GetItems(new CamlQuery
            {
                ViewXml = "<View><Query><Where><Eq><FieldRef Name='FileLeafRef'/><Value Type='Text'>" + filename + "</Value></Eq></Where></Query></</View>"
            });
            context.Load(sourceListItems);
            context.ExecuteQuery();
            ListItem sourceListItem = null;
            if (sourceListItems != null && sourceListItems.Count() > 0)
                sourceListItem = sourceListItems.FirstOrDefault();
            var fileStream = sourceListItem.File.OpenBinaryStream();
            context.Load(sourceListItem);
            context.Load(sourceListItem.File);
            context.ExecuteQuery();
            return fileStream;
        }
