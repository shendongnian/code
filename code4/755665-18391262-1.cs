       private string _pinMessafe;
         public string pinmesssage
         {
             get {
                 return _pinMessafe ?? GetMessage()
             }
             set { _pinMessafe = value; }
         }
