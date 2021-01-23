    ExchangeService service = GetService(); 
            
    var iv = new ItemView(1000);
    string aqs = "System.Category:Processed";
    FindItemsResults<Item> searchResult = null;
    do
    {
        searchResult = service.FindItems(WellKnownFolderName.Inbox, aqs, iv);
        foreach (var item in searchResult.Items)
        {
            Console.WriteLine(item.Subject);
        }
        iv.Offset += searchResult.Items.Count;
    } while (searchResult.MoreAvailable == true);   
