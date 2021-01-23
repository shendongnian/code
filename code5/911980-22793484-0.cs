    CheckBoxList cbl = new CheckBoxList();
    ListItem li = new ListItem("test");
    li.Selected = true;
    cbl.Items.Add(li);
    Label labelTest = new Label();            
    string[] test = cbl.Items.Cast<ListItem>().Where(l => l.Selected)
                                              .Select(l => l.Value)
                                              .ToArray();
    labelTest.Text = String.Join("<br /", test);
