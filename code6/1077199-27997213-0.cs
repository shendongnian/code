    var adService = new DirectorySearcher(new DirectoryEntry());
        adService.Filter = "(&(objectClass=user)(anr=LOGON))";
        adService.PropertiesToLoad.Add("FirstName");
        adService.PropertiesToLoad.Add("LastName");
        adService.PropertiesToLoad.Add("SMTP");
        return adService.FindOne();
