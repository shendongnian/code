    using System;
    using System.Reflection;
    using System.Linq;
    			
    public class TicketStatus
    {
    	private string _guid;
    	
    	private TicketStatus(string guid)
    	{
    		_guid = guid;
    	}
    	
    	public string GuidValue {get {return _guid; } }
    	
    	public static readonly TicketStatus Open =  new TicketStatus("7ae15a71-6514-4559-8ea6-06b9ddc7a59a");
        public static readonly TicketStatus Closed =  new TicketStatus("41f81283-57f9-4bda-a03c-f632bd4d1628");
        public static readonly TicketStatus Hold =  new TicketStatus("41bcc323-258f-4e58-95be-e995a78d2ca8");
    	
    	//Reads all static readonly fields and selects the one who has the specified GUID
    	public static TicketStatus Identify(string guid)
    	{
    		var ticket = typeof(TicketStatus).GetFields()
    			         .Where(x => (x.IsStatic == true) && (x.IsInitOnly == true) )
    			         .Select(x => x.GetValue(null))
    				     .SingleOrDefault(x => (x as TicketStatus).GuidValue == guid)
    			         as TicketStatus;
    		return ticket;
    					 
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{	
    		var guid = "7ae15a71-6514-4559-8ea6-06b9ddc7a59a";
    		var ticket = TicketStatus.Identify(guid);
    		if(ticket != null)
    		{
    			Console.WriteLine(ticket.GuidValue + " found");
    		}
    		else
    		{
    			Console.WriteLine("unknown ticket");
    		}
    	}
    }
