     static  void GetChild(int id) // Pass parent Id
                    {
            
                        using (var ctx =  new CodingPracticeDataSourceEntities())
                        {
                            if (ctx.Trees.Any(x => x.ParentId == id))
                            {
                                var childList = ctx.Trees.Where(x => x.ParentId == id).ToList();
                                list.AddRange(childList);
                                foreach (var item in childList)
                                {
                                    GetChild(item.Id);
                                }
                                
                            }
            
                        }
                    }
