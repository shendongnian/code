    Public Class PersonViewModel
    {
         readonly Person _person;
    
         Public PersonViewModel(Person person)
         {
           _person = person;
         }
    
       public string Name
       {
           get { return _person.Name; }
           set 
           { 
               _person.Name = value;
               RaisePropertyChanged();
           }
       }
