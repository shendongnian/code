	public class EmailPair
	{
        public SmtpClient Client { get; set; }
        public MailMessage Email { get; set; }
	}
	public static void SendEmail(object state)
	{
	    var pair = (EmailPair) state;
	    try
	    {
	        pair.Client.Send(pair.Email);
	    }
	    catch (Exception e)
	    {
	        Log.Error(e);
	    }
	}
