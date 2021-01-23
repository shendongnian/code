    // Create a new ListView control. (or use the designer)
    ListView listView1 = new ListView();
    // Position and size of the ListView
    listView1.Bounds = new Rectangle(new Point(10,10), new Size(500,200));
    // Some display feature....
    listView1.View = View.Details;
    listView1.FullRowSelect = true;
    listView1.GridLines = false;
    // Add OEM Version value
    ListViewItem item = new ListViewItem("OEM Version");
    item.SubItems.Add(GetXMLData(doc, "OemMarkerVersion"));
    listView1.Items.Add(item);
    // Add OEM ID value
    item = new ListViewItem("OEM ID");
    item.SubItems.Add( GetXMLData(doc, "OemId"));
    listView1.Items.Add(item);
    ... and so on for the others values and labels ....
    // Some header formatting
    listView1.Columns.Add("Label", 100, HorizontalAlignment.Left);
    listView1.Columns.Add("Data", 400, HorizontalAlignment.Left);
    // Put the ListView on video....
    yourForm.Controls.Add(listView1);
