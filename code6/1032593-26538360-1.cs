    List<string> images = new List<string>();
    List<int> visibleItems = new List<int>();
    void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        if (!imageList1.Images.ContainsKey(images[e.ItemIndex]) ) loadImage(e.ItemIndex);
        e.DrawDefault = true;
        if (!visibleItems.Contains(e.ItemIndex)) visibleItems.Add(e.ItemIndex);
        if (visibleItems.Count > 100)
        {
           visibleItems.Clear(); 
           listView1.Invalidate();
        }
       
    }
    void loadImage(int index)
    {
        imageList1.Images.Add(images[index], new Bitmap(images[index]) );
    }
