    protected void RemoveAssignment(object sender, CommandEventArgs e)
    {
        int articleIDToDelete = 0;
        if (Int32.TryParse((string)e.CommandArgument, out articleIDToDelete))
        {
            //delete the article with an ID = articleIDToDelete
        }
    }
