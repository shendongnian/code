    Match Names = Regex.Match(item[2], @"(((?<=Name:(\s)))(.{0,60})|((?<=Name:))(.{0,60}))", RegexOptions.IgnoreCase);
    
    
    
    
     if (Names.Success)
                        {
                            String[] nameParts =  Names.ToString().Trim().Split(' ');
                                  int count = 0;
                                  foreach (String part in nameParts) {
                                        if(count == 0) {
                                              FirstName = part;
                                              count++;
                                        } else {
                                              LastName += part + " ";
                                        }
                                  }
                        }
