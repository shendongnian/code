        List<SelectListItem> itemsInStockSelectList = new List<SelectListItem>();           
        for (int x = 0; x < itemsList.Items.Count; x++)
        {
            var selectItem = new SelectListItem();
            selectItem.Text = itemsList.Items[x].InStockNow.ToString();
            selectItem.Text = itemsList.Items[x].InStockNow.ToString();
            itemsInStockSelectList.Add(selectItem);                
        }
