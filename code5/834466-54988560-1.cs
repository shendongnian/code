    private void OnMyMeasureItem(object sender, MeasureItemEventArgs e)
    {
        // measure logic goes here
        int myCustomHeightValue = 22;
        e.ItemHeight = myCustomHeightValue;
    }
    ListBox listBox = new ListBox();
    listBox.MeasureItem += OnMyMeasureItem;
    listBox.Resize += (sender, args) => ForceMeasureItems(listBox, OnMyMeasureItem);
