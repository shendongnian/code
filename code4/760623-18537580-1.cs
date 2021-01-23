    public class DataGridViewModel
    {
        public ObservableCollection<Selectable<Item>> Items { get; set; }
    
        public SomeMethod()
        {
           Items = new ObservableCollection<Selectable<Item>>();
    
           //Populate the Collection here!
           foreach (var item in Items)
               item.OnIsSelectedChanged = OnItemSelectedChanged;
        }
    
        private void OnItemSelectedChanged(Selectable<Item> item)
        {
           if (item.IsSelected)
           {
               var itemsToDeselect = Items.Where(x => x != item);
               
               foreach (var itemToDeselect in itemsToDeselect)
                   itemToDeselect.IsSelected = false;
           }
        }
    }
