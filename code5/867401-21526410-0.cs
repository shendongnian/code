            Dictionary<Type,Func<IBusiness,InvestmentReturn>> dict = new Dictionary<Type, Func<IBusiness, InvestmentReturn>>
            {
                {typeof (BookShop), business => new RetailInvestmentReturn((IRetailBusiness) business)},
                {typeof (AudioCDShop), business => new IntellectualRightsInvestmentReturn((IIntellectualRights) business)}
            };
