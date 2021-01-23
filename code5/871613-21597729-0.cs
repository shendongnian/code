    void AddTab()
    {
        TabPage tbp = new TabPage();
        tbp.Name=TabControl1.TabPages.Count.ToString();
        MyUserControl cnt = new MyUserControl();
        cnt.Name="Cnt" + tbp.Name;
        cnt.Dock=DockStyle.Fill;
        tbp.Controls.Add(cnt);
    }
