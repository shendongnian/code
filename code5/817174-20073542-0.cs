    public class Modem : IModemConnection, IModemDataExchange
    {
    	public IModemConnection Dialer {get; private set;}
    	
    	public Modem(IModemConnection Dialer)
    	{
    		this.Dialer=Dialer;
    	}
    	
    	public void Dial(string number)
    	{
    		Dialer.Dial(number);
    	}
    	
        public void Hangup()
    	{
    		Dialer.Hangup();
    	} 
    	
    	// .... implement IModemDataExchange
    }
