    Dictionary<char,int> dic=new Dictionary<char,int>();
    for(int i=1;i<list.count;i++)
    {
              if(list[i]==list[i-1])
                    {
                          if(dic.ContainsKey(list[i]))
                                     {
                                       dic[list[i]]+=1;
                                 }
                              else
                                     { 
                                        dic.Add(list[i],2)
                                      }
                      }
    }
