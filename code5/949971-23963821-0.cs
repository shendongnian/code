    public int Quantity
    {
         get { return quantity; }
         set
         {
            quantity= value;
            NotifyPropertyChanged("Quantity");
            NotifyPropertyChanged("Amount");
         }
     }
        
    public int Price
    {
         get { return price; }
         set
         {
             price= value;
             NotifyPropertyChanged("Price");
             NotifyPropertyChanged("Amount");
         }
    }
           
    public long Amount
    {
        get { return (Amount*Price); }
    }
