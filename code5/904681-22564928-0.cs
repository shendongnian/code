    public void ReplaceCommaInTag(KbContext kb)
     {
        var tags = from t in kb.Titles
                   Select t.Tags;
        foreach(Tag tag in tags)
         {
          tag = tag.Replace(","," ");
         }
        try
        {
         kb.SubmitChanges();
        }
   
        catch(Exception e)
        {
        //Display the error.
        }
    }
