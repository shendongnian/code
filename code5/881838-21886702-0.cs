    TableLayoutPanel tlp = new TableLayoutPanel();
    tlp.Dock = DockStyle.Fill;
    int row = 0;
    foreach (string s in File.ReadAllLines("file.txt"))
    {
        tlp.RowStyles.Add(new RowStyle());
        TextBox tb = new TextBox();
        tb.Text = s;
        tlp.Controls.Add(tb, 0, row++);
    }
    this.Controls.Add(tlp);
