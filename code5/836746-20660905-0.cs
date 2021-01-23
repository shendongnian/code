        using (var faxHistory = new waldenEntities())
        {
            IQueryable<FaxesSendServer> faxHistoryJson  
                = (System.Linq.IQueryable<WaldenCompleteFaxWeb.Models.FaxesSendServer>)faxHistory.FaxesSendServers.Where(p => p.UserID.Contains("walden"));
            IQueryable faxHistoryJson
                = (System.Linq.IQueryable<WaldenCompleteFaxWeb.Models.FaxesSendServer>)faxHistory.FaxesSendServers.Select(c => c.Status);
        }
    }
