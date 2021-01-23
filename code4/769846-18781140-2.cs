    foreach (FileInfo i in corFiles)
    {
       LinkButton t = new LinkButton();
       t.Text = i.Name;
       t.Click += new EventHandler(DynamicClick);
       t.CommandName = i.Name;
       CorrectArray.Add(t);
    }
    void DynamicCommand(Object sender, CommandEventArgs e) 
    {
         // using e.CommandName and e.CommandArgument you can differentiate the hyperlinks
    }
