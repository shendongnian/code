    ImageList imageList1 = new ImageList();
    imageList1.Images.Add("key1", Image.FromFile(@"C:\path\to\file.jpg"));
    imageList1.Images.Add("key2", Image.FromFile(@"C:\path\to\file.ico"));
           
    TabControl tabControl1 = new TabControl();
    tabControl1.Dock = DockStyle.Fill;
    tabControl1.ImageList = imageList1;
    tabControl1.TabPages.Add("tabKey1", "TabText1", "key1");  
    tabControl1.TabPages.Add("tabKey2", "TabText2", "key2");
    this.Controls.Add(tabControl1);
