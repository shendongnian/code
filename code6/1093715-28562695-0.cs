        var newTitle = TitleHelper.GenerateNewTitle(i.Value, /* .. */);
        if(newTitle.Title_Id > 0)
    {
     // Query to update your record
    }
    else
    {
      //add and save
      context.Titles.Add(newTitle);                        
      await context.SaveChangesAsync();
    }
                           
