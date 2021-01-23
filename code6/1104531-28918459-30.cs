    Public Class Email
    {
       public Email()
       {
         Method = ViaPop;//declare the default method on instantiation
       }
       //define the delegate
       public delegate void SendMailMethod(string title, string message);
       //declare a variable of type SendMailMethod
       public SendMailMethod Method;
       public string To {get;set;}
       //Omitted code
    
       public void Send()
       {
         //assume title and message strings have been determined already
         Method(title, message);
       }
       public void SetToPop()
       {
         this.Method = ViaPop;
       }
       public void SetToImap()
       {
         this.Method = ViaImap;
       }
       //You can write some default methods that you forsee being needed
       private void ViaImap(string title, string message) {...}
       private void ViaPop(string title, string message) {...}
    }
