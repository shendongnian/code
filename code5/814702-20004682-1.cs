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
     PercentPopLis.Add("10");
     PercentPopLis.Add("11");
    
    
     int totItems = SeqIrregularities.Count - 1;
     if (MaxLen.Count - 1 > totItems) totItems = MaxLen.Count - 1;
     if (PercentPopLis.Count - 1 > totItems) totItems = PercentPopLis.Count - 1;
    
     for (int i = 0; i <= totItems; i++)
     {
         ListViewItem lvi = new ListViewItem();
         string item1 = "";
         string item2 = "";
         string item3 = "";
    
         if (SeqIrregularities.Count - 1 >= i) item1 = SeqIrregularities[i];
         if (MaxLen.Count - 1 >= i) item2 = MaxLen[i];
         if (PercentPopLis.Count - 1 >= i) item3 = PercentPopLis[i];
    
         lvi.SubItems.Add(item1);
         lvi.SubItems.Add(item2);
         lvi.SubItems.Add(item3);
    
         listView1.Items.Add(lvi);
     }
