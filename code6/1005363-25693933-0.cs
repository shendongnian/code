    for (int i = 0; i < RadGrid1.EditItems.Count; i++)
    {
        var items = ((RadGrid1.MasterTableView.Items[i].ChildItem as GridNestedViewItem)
            .FindControl("RadGrid2") as RadGrid).EditItems;
        foreach (GridEditableItem editItem in items)
        {
            Hashtable newValues = new Hashtable();
            editItem.OwnerTableView.ExtractValuesFromItem(newValues, editItem);
            foreach (DictionaryEntry de in newValues)
            {
                string valOld = (editItem.SavedOldValues[de.Key] as string) ?? "";
                string valNew = (newValues[de.Key] as string) ?? "";
    
                // valNew contains new values if they were changed by the user!
            }
        }
    }
