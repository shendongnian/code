    collection.FirstOrDefault(x => { 
                                     if(x.Field == null)
                                     {
                                           throw new ScriptException("{0}", x.y);
                                     }
                                     return false;
                                    }
                              );
