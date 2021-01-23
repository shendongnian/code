    var defaultList = asgmps
            .Where(asgmp => asgmp.IsChecked)
            .Select(asgmp => new
                {
                    IsDefault = asgmp.IsDefault,
                    Item =  new DefaultItem
                        {
                            ID = asgmp.ID,
                            Name = GetMPTName(asgmp.ID)
                        }
                }).ToList();
