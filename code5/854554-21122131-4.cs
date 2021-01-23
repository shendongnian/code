     context.Book.ToList().ForEach(n => bs.Add(n)); 
     // attach event after fill data
     bs.ListChanged += bs_ListChanged;
     bstab2.ListChanged += bstab2_ListChanged; 
    
    void bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    context.LibraryStock.Book.Add((Book)((BindingSource)sender).List[e.NewIndex]); // Adding to Navigating Collection 
                    break;
                case ListChangedType.ItemDeleted:
                    contextBook.Remove((Book)((BindingSource)sender).List[e.OldIndex]);
                    break;
            }
          
        }
    void bstab2_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    context.LibraryStock.Add((LibraryStock)((BindingSource)sender).List[e.NewIndex]);
                    break;
                case ListChangedType.ItemDeleted:
                    context.LibraryStock.Remove((LibraryStock)((BindingSource)sender).List[e.OldIndex]);
                    break;
            }
          
        }
    //detaching events for reloading data 
    bs.ListChanged -= bs_ListChanged;
    // here reloading data from dbase
    bs.ListChanged += bs_ListChanged;
