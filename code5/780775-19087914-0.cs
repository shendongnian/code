    for (int i = 0; i < list.Items.Count; i++)
    {
        try
        {
           SPListItem item = list.Items[i];
           // your code 
        }
        catch (NullReferenceException ex)
        {
            Logger.Error("[{0}] Filed moving on file {1} as not all content was present", item.Name);
        }
       
    }
