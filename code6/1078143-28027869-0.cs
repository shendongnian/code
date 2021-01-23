        public class User : BindableBase
        {
           private string _firstName;
           private string _lastName;
           private string _age;
    
        public string Firstname  
        { 
          get{ return _firstName;} 
          set
          {
               _firstName = value;
               OnPropertyChanged(() => Firstname);
          }
        }
    
        public string LastName
        { 
          get{ return _lastName;} 
          set
          {
               _lastName = value;
               OnPropertyChanged(() => LastName);
          }
        }
    
        public string Age
        { 
          get{ return _age;} 
          set
          {
               _age = value;
               OnPropertyChanged(() => Age);
          }
        }
    }
