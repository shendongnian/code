    public class Car
    {
      public string Model;
      public int Speed;
    }
      
    class MyViewModel: INotifyPropertyChanged
    {
      List<Car> cars;
    
      public List<Car> Cars { get {return cars;}}
    
      // this method is invoked from GUI, ie from an event handler or a Command of a "Reload" button
      public void ReloadData()
      {
        // do something to actually refresh cars
    
        // notify GUI something changed
        InternalPropertyChanged("Cars");
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected void InternalPropertyChanged(string name)
      {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }
