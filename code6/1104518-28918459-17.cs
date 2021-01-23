    Public Class Email
    {
       public Email()
       {
         SendMailMethod = ViaPop;//declare the default method on instantiation
       }
       //define the delegate
       public delegate void SendMailMethod(string title, string message);
       public string To {get;set;}
       //Omitted code
    
       public void Send()
       {
         //assume title and message strings have been determined already
         SendMailMethod(title, message);
       }
       //You can write some default methods that you forsee being needed
       private void ViaImap(string title, string message) {...}
       private void ViaPop(string title, string message) {...}
    }
