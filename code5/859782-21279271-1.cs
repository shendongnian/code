    TabControl tbdynamic = new TabControl();
    tbdynamic.Height = 200;
    tbdynamic.Width = 200;
    TabPage mPage = new TabPage();
    mPage.Text = "Test Page";
    tbdynamic.TabPages.Add(mPage);
    
    mPage.Controls.Add(statictabcontrol);
    this.Controls.Add(tbdynamic);
                
