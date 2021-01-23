    public class DataItem
    {
       private string _cell;
       public string cell //Why is your property named like this, anyway?
       {
           get { return _cell; }
           set
           {
               _cell = value;
               NotifyPropertyChange("cell");
     
               //OR
      
               NotifyPropertyChange(() => cell); //if you're using strongly typed NotifyPropertyChanged.
           }
       }
    }
