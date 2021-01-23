    var fListItem = db.FListItems.Include(f => f.FList)
                                 .Include(f => f.FItem)
                                 .Select(f => new FListVM
                                    {
                                        Title = f.FList.Title,
                                        Posted = f.FList.Posted,
                                        FItemVMs = new List<FItemVM>()
                                        {
                                            new FItemVM{
                                               Name ="somename"
                                            },
                                            new FItemVM{
                                            }
                                        }
                                    }).OrderByDescending(f => f.Posted).ToList();
