    var results = stockValues.Aggregate(new List<DailyValues>(), (a,b)=>{
                                        if (a.Count == 0) a.Add(b);
                                        else if (b.High >= a[0].High){
                                          if(b.High > a[0].High) a.Clear();
                                          a.Add(b);
                                        }                
                                        return a;
                                     });
