     StoreDetailModel store = 
                   StoresWithDepartmentType.FirstOrDefault(x => x.Item.ID ==    
                                                 currentUserStore.Item.ID);
                if (store == null)
                {
                    store = StoresWithDepartmentType.First();
                }
                return store;
