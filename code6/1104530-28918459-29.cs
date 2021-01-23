    Public Class Email
    {
       public string To {get;set;}
       //Omitted code
    
       public void Send(MailMethod method)
       {
         switch(method)
         {
           case MailMethod.Imap:
             ViaImap();
             break;
           case MailMethod.Pop:
             ViaPop();
             break;
          }
       }
       private void ViaImap() {...}
       private void ViaPop() {...}
    }
