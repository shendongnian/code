    TabControl tbdynamic = new TabControl();
    tbdynamic.Height = 200;
    tbdynamic.Width = 200;
    TabPage mPage = new TabPage();
    mPage.Text = "Test Page";
    tbdynamic.TabPages.Add(mPage);
    
    mPage.Controls.Add(statictabcontrol);
    statictabcontrol.Top = 0;
    statictabcontrol.Left = 0;
    this.Controls.Add(tbdynamic);
                
