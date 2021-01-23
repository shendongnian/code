    TabControl newTab = new TabControl();
    flowLayoutPanel1.Controls.Add(newTab);
    newTab.TabPages.Add(new TabPage("111"));
    newTab.TabPages.Add(new TabPage("222"));
    newTab.TabPages.Add(new TabPage("333"));
    Button newButton = new Button();
    flowLayoutPanel1.Controls.Add(newButton);
    // here we create the handler with its code:
    newButton.Click += ((sender2, evt) => { newTab.SelectedIndex = 2; });
