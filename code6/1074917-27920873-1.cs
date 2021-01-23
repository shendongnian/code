    private void Panorama_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count < 1) return;
        if (!(e.AddedItems[0] is PanoramaItem)) return;
        PanoramaItem selectedItem = e.AddedItems[0] as PanoramaItem;
        string tag = selectedItem.Tag.ToString();
        if (tag.Equals("sample2"))
            // user flick from right to left
        else if (tag.Equals("sample3"))
            // user flick from left to right
     }
