    List<string> images = new List<string>();
    List<int> visibleItems = new List<int>();
    void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        // this loads the images on demand:
        if (!imageList1.Images.ContainsKey(images[e.ItemIndex]) ) 
           { loadImage(e.ItemIndex); e.Item.ImageIndex = imageList1.Images.Count - 1; }
        // this makes sure the listView is drawn by the system
        e.DrawDefault = true;
        // these lines would maintain a list of items that are or were recently visible
        if (!visibleItems.Contains(e.ItemIndex)) visibleItems.Add(e.ItemIndex);
        if (visibleItems.Count > 1000)
        {
           visibleItems.Clear(); 
           imageList1.Images.Clear();
           listView1.Invalidate();
        }
       
    }
    void loadImage(int index)
    {
        imageList1.Images.Add(images[index], new Bitmap(images[index]) );
    }
