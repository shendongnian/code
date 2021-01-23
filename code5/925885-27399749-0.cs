    public class Foo : INotifyPropertyChanged 
    {
         public event PropertyChangedEventHandler PropertyChanged;
         
         [NotifyPropertyChangedInvocator]
         protected virtual void NotifyChanged(string propertyName) { ... }
      
         private string _name;
         public string Name {
           get { return _name; }
           set { 
                 _name = value; 
                 NotifyChanged("LastName");//<-- warning here
               } 
         }
       }
