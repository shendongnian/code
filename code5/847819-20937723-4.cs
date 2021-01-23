    var target = CustomerItems.Select((item, index) => new 
                                  { 
                                      Line = String.Format("Line {0}", index + 1), 
                                      Item = item.ToString()
                                  })
                              .ToDictionary(i => i.Line, i => i.Item);
