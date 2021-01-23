     public string Name
     {
       get 
        { 
          if (string.IsNullOrEmpty(name))
           {
             throw new ArgumentException("Name can not be empty");
           }
          return name;
         }
       set 
         {  
             name = value; 
             NotifyPropertyChanged(); 
         }
      }
