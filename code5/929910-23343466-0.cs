    <telerik:RadCollectionNavigator CurrentItem={Binding CurrentItem} />
        
    public Address CurrentItem
        {
           get; set;
        }
    
    public IEnumerable<Rentals> Rentals
    {
       get { return CurrentItem.Rentals; }
    
    } 
