    ListView lv = new ListView();
    lv.Columns.Add("Header", 100);
    lv.Columns.Add("Details", 100);
    lv.Dock = DockStyle.Fill;
    lv.Items.Add(new ListViewItem(new string[] { "Sachin", "Some details" }));
    lv.Items.Add(new ListViewItem(new string[] { "Stats", "More details" }));
    lv.View = View.Details;
    Controls.Add(lv);
