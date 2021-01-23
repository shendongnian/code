    public class Sample : INotifyPropertyChanged
    {
    
      DomainContextVBHS _Service = new DomainContextVBHS();
    
      public Sample()
      {
         _Service.Customers.PropertyChanged += PropChanged;
         _Service.Orders.PropertyChanged += PropChanged;
         // etc.
      }
    
      public int AddedEntitiesCount
      {
        get{ return _Service.EntityContainer.GetChanges().AddedEntities.Count; }
      }
    
      public PropChanged(object sender, PropertyChangedEventArgs e)
      {
        var pc = this.PropertyChanged;
        if (pc != null) 
        {
           pc(this, new PropertyChangedEventArgs("AddedEntitiesCount");
           pc(this, new PropertyChangedEventArgs("RemovedEntitiesCount");
           // etc
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    }
