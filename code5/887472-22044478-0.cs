    string s = "pencil";
            
    string str = new string(s.Select((c, index) => 
                              {
                                  if (index < 3)
                                      return Char.ToUpper(c);
                                  else
                                      return c;
                              }).ToArray());
    Console.WriteLine(str); // output: PENcil
