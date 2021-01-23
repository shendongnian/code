    string pname = cbItem.SelectedItem.ToString();
    var result = DC.tblProducts.Where(p => p.ProductName == pname);
    
    var myList = new List<TblProductType>();
    foreach(var v in result)
    {
        myList.Add(v);
    }
    listview.ItemsSource = myList;
