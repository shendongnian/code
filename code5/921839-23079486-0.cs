    public class DetailsViewModel
    {    
        public DetailsViewModel()
        {
                
            Messenger.Default.Register<Item>(this, "ItemDetails", i=> ViewItemDetails(i));
        }
    
        public void ViewItemDetails(Item i)
        {            
           //Now you can bind it to your UI
        }
    }
