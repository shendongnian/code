        if (FUFile.PostedFile.ContentLength != 0)
        {
            string file = Path.GetFileName(FUFile.PostedFile.FileName);
            string tempVar = Path.Combine("~/res/Posts/", file);
            FUFile.PostedFile.SaveAs(Server.MapPath(tempVar));
           ftier.Addpostfromfront(LoggedUserID, "4", txpost.Value, tempVar,  DateTime.Now, DateTime.Now, false, false);
        }
