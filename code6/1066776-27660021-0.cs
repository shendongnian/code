    public void Form1_Load(object sender, EventArgs e)
    {
        TabPage t = new TabPage();
        Form2 newtab = new Form2();
        newtab.Show(this);          //note the change here
        newtab.TopLevel = false;
        newtab.Dock = DockStyle.Fill;
        t.Controls.Add(newtab);
        tabControl1.TabPages.Add(t);
    }
