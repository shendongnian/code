            //Return one result--there should only be one in this case
            ItemView view = new ItemView(1);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            //variables
            SearchFilter sfSearchFilter;
            FindItemsResults<Item> findResults;
            //for each string in list
            foreach (string s in permURLs)
            {
                //Search ItemSchema.Body for the string
                sfSearchFilter = new SearchFilter.ContainsSubstring(ItemSchema.Body, s);
                findResults = service.FindItems(WellKnownFolderName.Calendar, sfSearchFilter, view);
                if (findResults.TotalCount != 0)
                {
                    Item appointment = findResults.FirstOrDefault();
                    appointment.SetExtendedProperty(extendedPropertyDefinition, s);
                    ...
                    appointment.Load(new PropertySet(ItemSchema.Body));
                    string strBody = appointment.Body.Text;
                }
             }
