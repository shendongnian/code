    Dictionary<string, List<MenueStructure>> childs = new Dictionary<string, List<MenueStructure>>
                                                                  {
                                                                      {"TEACHERS", chlidObj1},
                                                                      {"STUDENTS", chlidObj2}
                                                                  };
    string json = JsonConvert.SerializeObject(childs, Formatting.Indented);
