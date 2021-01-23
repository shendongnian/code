        class ReportType {
            MerchantRepresentativeId,
            TotalRevenu
        }
        /* ... */
        using (AppDbContext db = new AppDbContext())
        {
            if (merchantId > 0)
            {
                var comms = 
                    from com in db.Commissions
                    group com by com.MerchantRepresentativeId into comGroup
                    select new ReportType {
                        MerchantRepresentativeId = com.MerchantRepresentativeId,
                        TotalRevenu = comGroup.Sum(x => x.TotalRevenu)                    
                    }
                   
                return comms.ToList();  **//This line is here to get the project to compile**
            }
            else
            {
                return new List<ReportType>();
            }
        }
