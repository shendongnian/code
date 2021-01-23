    private void LoadListview()
    {
        string NAME = "John DOE";
        string AGE = "30";
        string SEX = "MALE";
        string DOB = "08/28/1988";
    
        string[] rowa = { NAME, AGE, SEX, DOB };
        var listViewItema = new ListViewItem(rowa);
    
        listView1.Items.Add(listViewItema);
        listView1.Items.Add(listViewItema);
        listView1.Items.Add(listViewItema);
        listView1.Items.Add(listViewItema);
    
    }
