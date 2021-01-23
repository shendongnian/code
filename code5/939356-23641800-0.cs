    public SomeClass {
        public event EventHandler<EventArgs> AuthenticateEvent;  
        boolean isAuthenticated;
    
        public bool Authenticate()
        {
            // Do things
            isAuthenticated = true;
            AuthenticateEvent(this, new EventArgs());
        }
    }
    
    public MainWindow()
    {
       SomeClass temp = new SomeClass();
     
       public MainWindow(){
          temp.AuthenticateEvent+= OnAuthentication;
          temp.Authenticate();
       }
    
       private void OnAuthentication(object sender, EventArgs e){
           Dispatcher.Invoke(() => {
               label.Content = "AUTHENTICATED";
           }); 
       }
    }
