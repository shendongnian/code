    Public Class Email
    {
       public event EventHandler<EventArgs> Sent;
       private void OnSent(EventArgs e)
        {
            if (Sent!= null)
                Sent(this, e);
        }
       public string To {get;set;}
       //Omitted code
    
       public void Send()
       {
        //Omitted code that sends.
        OnSent(new EventArgs());//raise the event
       }
    }
