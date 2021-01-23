    MyTabPage page = new MyTabPage();
    page.Button1Clicked += page_Button1Clicked;
    tabControl.TabPages.Add(page);
    ...
    void page_Button1Clicked(object sender, EventArgs e)
    {
    }
