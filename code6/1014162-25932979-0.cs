    listView1.Columns.Add("Col1");
    listView1.Columns.Add("Col2");
    string[] strArrGroups = new string[3] { "FIRST", "SECOND", "THIRD" };
    string[] strArrItems = new string[4] { "uno", "dos", "twa", "quad" };
    for (int i = 0; i < strArrGroups.Length; i++)
     {
        int groupIndex = listView1.Groups.Add(new ListViewGroup(strArrGroups[i],HorizontalAlignment.Left));
    for (int j = 0; j < strArrItems.Length; j++)
    {
        ListViewItem lvi = new ListViewItem(strArrItems[j]);
        lvi.SubItems.Add("Hasta la Vista, Mon Cherri!");
        listView1.Items.Add(lvi);
        listView1.Groups[i].Items.Add(lvi);
    }
} 
