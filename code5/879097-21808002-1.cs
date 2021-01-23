    List<Test> tests = new List<Test>
                           {
                               new Test
                                   {
                                       Name = "Test1",
                                       Value = 100
                                   },
                               new Test
                                   {
                                       Name = "Test2",
                                       Value = 80
                                   }
                           }
    DropDownList ddl = new DropDownList();
    ddl.DataSource = list;
    ddl.DataTextField = "Name"; // property u wanna display
    ddl.DataValueField = "Value"; // property u wanna retrieve value from
    ddl.DataBind();
    ddl.SelectedIndex = 0; // if u want to select the very 1st item by default
