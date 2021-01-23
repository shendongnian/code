    public string GetMenue()
    {
        List<MenueStructure> chlidObj1 = new List<MenueStructure>();
        chlidObj1.Add(new MenueStructure
                              {
                                  ID = "1",
                                  ParentID = "",
                                  ChildID = "1",
                                  MenuName = "Registration",
                                  MenuLink = "Registration.aspx"
                              });
        chlidObj1.Add(new MenueStructure
                              {
                                  ID = "2",
                                  ParentID = "1",
                                  ChildID = "2",
                                  MenuName = "Assign Subject",
                                  MenuLink = "AssignSubject.aspx"
                              });
        List<MenueStructure> chlidObj2 = new List<MenueStructure>();
        chlidObj2.Add(new MenueStructure
                              {
                                  ID = "1",
                                  ParentID = "",
                                  ChildID = "1",
                                  MenuName = "Registration",
                                  MenuLink = "Registration.aspx"
                              });
        chlidObj2.Add(new MenueStructure
                              {
                                  ID = "2",
                                  ParentID = "1",
                                  ChildID = "2",
                                  MenuName = "Assign Subject",
                                  MenuLink = "AssignSubject.aspx"
                              });
        Dictionary<string, List<MenueStructure>> childs = new Dictionary<string, List<MenueStructure>>
                                                                  {
                                                                      {"TEACHERS", chlidObj1},
                                                                      {"STUDENTS", chlidObj2}
                                                                  };
        string json = JsonConvert.SerializeObject(childs, Formatting.Indented);
        var deserializeObject = JsonConvert.DeserializeObject<Dictionary<string, List<MenueStructure>>>(json);
        return json;
