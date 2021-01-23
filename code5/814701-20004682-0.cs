    List<string> SeqIrregularities = new List<string>();
    SeqIrregularities.Add("1");
    SeqIrregularities.Add("2");
    SeqIrregularities.Add("3");
    
    List<string> MaxLen = new List<string>();
    MaxLen.Add("4");
    MaxLen.Add("5");
    MaxLen.Add("6");
    
    List<string> PercentPopLis = new List<string>();
    PercentPopLis.Add("7");
    PercentPopLis.Add("8");
    PercentPopLis.Add("9");
    
    int totItems = SeqIrregularities.Count - 1;
    for (int i = 0; i <= totItems; i++)
    {
        ListViewItem lvi = new ListViewItem();
        lvi.SubItems.Add(SeqIrregularities[i]);
        lvi.SubItems.Add(MaxLen[i]);
        lvi.SubItems.Add(PercentPopLis[i]);
    
        listView1.Items.Add(lvi);
    }
