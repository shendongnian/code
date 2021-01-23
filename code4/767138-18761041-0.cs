    if (tabcontrol1.TabPages.ContainsKey("tabpagename")) 
    {
       //select existing tab page by "Name" or say "Key"
      tabcontrol1.SelectTab("tabpagename");
    }
    else
    {
       //create new tab page
      TabPage tabpagep1 = new TabPage("");
      tabpagep1.Name = "tabpagename";    
      tabcontrol1.TabPages.Add(tabpagep1);
    }
