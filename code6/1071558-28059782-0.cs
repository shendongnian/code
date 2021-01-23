    // To Copy
    newPage = new TabBarPage();
    foreach (Control c in this.tabBarSplitterControl1.ActivePage.Controls)
    {
        Control cNew = (Control)Activator.CreateInstance(c.GetType());
    
        PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(c);
    
        foreach (PropertyDescriptor entry in pdc)
        {
            object val = entry.GetValue(c);
            entry.SetValue(cNew, val);
        }
        newPage.Controls.Add(cNew);
    }
    newPage.Text = "New Tab";
    
    // To Paste
    this.tabBarSplitterControl1.TabBarPages.Add(newPage);
