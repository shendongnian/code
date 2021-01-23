    var newList = theList.SelectMany((x,i)=>
                                     theList.Where((y,j)=>j>i && y.Propery2 == x.Propery1)
                                            .Select(a=> new ReportObject{
                                                          Property1=x.Property1,
                                                          Property2=x.Property1
                                                          });
                         
                                     
                              
