    namespace Example
    {
    	class Program
    	{
    		private static SmtpClient _smtp = null;
    		public static SmtpClient Smtp
    		{
    			get
    			{
    				if (_smtp == null)
    				{
    					_smtp = new SmtpClient("relay.your-smtp-host.com", 25);
    					_smtp.UseDefaultCredentials = true;
    				}
    				return _smtp;
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			using (MailMessage ms = new MailMessage())
    			{
    				var from = new MailAddress("from@email-address.com", "**THE NAME MUST CONTAINS SOME NON ANSI CHARS**");
    
    				string s = from.ToString(); /* This is the line - comment it and everything will work fine! */
    
    				ms.From = from;
    				ms.To.Add(new MailAddress("recipient@address.co.il"));
    				ms.Subject = "Here is my message title";
    				ms.Body = "Here is my message body";
    				Smtp.Send(ms);
    			}
    		}
    	}
    }
