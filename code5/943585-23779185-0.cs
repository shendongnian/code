    public void createRpt(string reportNum, Object selectedItems)
    {
        var items = (System.Collections.IList)selectedItems;
        //var typedItems = items.Cast<YourCustomType>();
        foreach(var item in items)
        {
          //Do something with items
        }
    }
