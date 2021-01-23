    var map = new List<mapItem>
                  {
                      new mapItem
                          {
                              offset = 0,
                              length = 1,
                              newString = "frog"
                          },
                      new mapItem
                          {
                              offset = 9,
                              length = 1,
                              newString = "kva"
                          }
                  };
    string str = "dog says gav";
    var result = str.ReplaceSubstringByMap(map);
