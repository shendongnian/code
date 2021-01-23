    //This is command defining 
    private ICommand myCommand; 
                       
    public ICommand MyCommand
    {
       get
       {
          if (myCommand== null)
             myCommand= new RelayCommand(MyMethod);
          return myCommand;
       }
       set { myCommand= value; }
    }
                    
                    
      //This is your command method
      public void MyMethod()
      {
      }
                    
      //This is your xaml
      <Button Command="{Binding MyCommand}"/>
            
            
