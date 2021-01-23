    // Specify ONLY the site collection here
    using (SPSite spsitecollection = new SPSite("http://sharepoint/sites/" + srcSiteCollection))
    {
        // Specify the site/subsite
        using (SPWeb spweb = spsitecollection.OpenWeb(srcSite))
        {
            
            spweb.AllowUnsafeUpdates = true;
            SPFolder spfolder = spweb.GetFolder(path);
            // No errors anymore!
            if (spfolder == null || !spfolder.Exists)
                response = "Folder Does Not Exist!";
            else
                response = "Folder Exists!";
        }
    }
