    List<Model.BeneficiaryItem> oldListItem = listItem;
    List<Model.DataType> newListItem = new List<Model.DataType>();
    ListView.ItemsSource = newListItem; 
    //update the data
    for (int i = 0; i < oldListItem.Count; i++)
    {
     Model.DataTyep benItem = new Model.DataTyep ();
     // update the individual object  benItem          
    newListItem.Add(benItem);
    }
    ListViewBenList.ItemsSource = newListItem;
