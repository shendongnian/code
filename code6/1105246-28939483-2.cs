    UpdateSite(ManageEngineUpdateSite siteToUpdate)
    {
        // Do generic things
        UpdateSite((ManageEngineSite) siteToUpdate);
    
        var oldsiteName = siteToUpdate.oldsiteName;
        // Do specific things
        ...
    }
