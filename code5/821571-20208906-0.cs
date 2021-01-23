                     Dictionary<string,List<int>> dict = new Dictionary<string,List<int>>();
                     if(dict.ContainsKey(wordkey))
                              //update the key
                              dict[word].Add(newIndex);
                      else
                     {
                        var newList = new List();
                         newList.Add(index);
                         dict.Add(worditem,newList);
                      }
       
