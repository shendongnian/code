    List<int> visibleItems = new List<int>();
    void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
        if (!visibleItems.Contains(e.ItemIndex)) visibleItems.Add(e.ItemIndex);
        if (visibleItems.Count > 100)
        {
           visibleItems.Clear(); 
           listView1.Invalidate();
        }
        synchImages();
    }
