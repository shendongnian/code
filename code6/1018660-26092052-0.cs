    private void button1_Click(object sender, EventArgs e)
    {
        TabPage t = new TabPage();
        t.Controls.Add(new UserControl1() { Dock = DockStyle.Fill });
        tabControl1.TabPages.Add(t);
    }
