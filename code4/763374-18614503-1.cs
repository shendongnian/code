    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        MyLbx.ItemsSource = new List<ItemModel> 
        {
            new ItemModel("Item name 8", "Item code 10", 180.76, 13),
            new ItemModel("Item name 19", "Item code 16", 153.68, 14),
            new ItemModel("Item name 8", "Item code 18", 195.71, 10),
            new ItemModel("Item name 11", "Item code 16", 112.71, 14),
            new ItemModel("Item name 5", "Item code 11", 156.09, 18),
            new ItemModel("Item name 7", "Item code 8", 124.38, 18),
            new ItemModel("Item name 16", "Item code 16", 129.31, 15),
            new ItemModel("Item name 13", "Item code 5", 187.55, 19),
            new ItemModel("Item name 6", "Item code 6", 146.10, 14),
            new ItemModel("Item name 19", "Item code 5", 154.84, 18),
            new ItemModel("Item name 15", "Item code 5", 149.69, 18),
            new ItemModel("Item name 17", "Item code 5", 155.39, 6),
            new ItemModel("Item name 6", "Item code 14", 119.19, 12),
            new ItemModel("Item name 14", "Item code 19", 186.40, 19),
            new ItemModel("Item name 7", "Item code 18", 178.30, 8),
            new ItemModel("Item name 12", "Item code 17", 105.60, 8),
            new ItemModel("Item name 5", "Item code 19", 120.94, 9),
            new ItemModel("Item name 9", "Item code 12", 164.13, 19),
            new ItemModel("Item name 18", "Item code 15", 119.24, 7),
            new ItemModel("Item name 16", "Item code 10", 106.30, 16)
        };
    }
    
    private async void btnPrint_Click(object sender, RoutedEventArgs e)
    {
        string PrintText = "";
        foreach (ItemModel item in MyLbx.Items)
        {
            PrintText += "Item name : " + item.ItemName + "\n";
            PrintText += "Item code : " + item.ItemCode + "\n";
            PrintText += "Price : " + item.Price + "\n";
            PrintText += "Quantity : " + item.Quantity + "\n\n";
        }
    
        await PrintHelper.ShowPrintUIAsync(printCanvas, PrintText, "PrintedListBox.pdf");
    }
