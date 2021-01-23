    //First just write below lines in IOC    
   
    this.For<IMessageService>().Use<EmailService>();
    this.For<IMessageService >().Use<EmailService>();
    //Then We can directly declare in our constructor injection of our class                             
    //Where we need it
    IEnumerable<IMessageService> messageServices;  
    public ClassNeedsInjection(IEnumerable<IMessageService> messageServices)                         
    {
        this.messageServices=messageServices;
        foreach (var messageService in this.messageServices)
        {
            //use both the objects as you wish
        }
    }
