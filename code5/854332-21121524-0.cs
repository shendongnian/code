    Private void AddpostfromFront()  //I don't like your naming on this, should be AddPostFromFront
    {
        if (FUFile.HasFile)
        {
            string tempVar = "~/res/Posts/" + FUFile.Value.ToString();
            FUFile.SaveAs(tempVar);
        }
    }
