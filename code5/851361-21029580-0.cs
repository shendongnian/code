                     var tableDictionary = db.Set<T>().ToDictionary(x => x.KeyValue, x => x);
                    foreach(var entity in entities) {
                        if (tableDictionary.ContainsKey(entity.yKeyValue))
                        {
                            list1.Add(entity);
                        }
                        else
                        {
                            list2.Add(entity);
                        }
                    }
