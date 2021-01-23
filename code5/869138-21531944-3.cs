    public RelayCommand TestCommand{ get; set; } 
    
    TestCommand= new RelayCommand( TestMethode);  
    
        private void TestMethode( SelectionChangedEventArgs args )  
        {  
            //TODO   args.AddItems can be help 
        }
