    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{	
    		var query = 
    			from Cash 
    			in _DataTable_Cash.AsEnumerable()
    			join CashOpeningsAssignments 
    			in _DataTable_CashOpeningsAssignments.AsEnumerable()
        			.Where(a => 
          				(a.cashopeningassignmentstatus_id == 1 || 
          				 a.cashopeningassignmentstatus_id == 2))
      			on Cash.cash_id 
    			equals CashOpeningsAssignments.cash_id 
      			into into_cashopeningsassignments
    			
    			from CashOpeningsAssignments 
    			in into_cashopeningsassignments.DefaultIfEmpty(new CashOpeningsAssignments()) 
    			join Users 
    			in _DataTable_Users.AsEnumerable()
    			on CashOpeningsAssignments.user_id 
    			equals Users.user_id
    			into into_users
    			
    			from Users 
    			in into_users.DefaultIfEmpty() 
    			select new
                {
    				cash_id = Cash.cash_id,
    				// cellar_name = Cellars.cellar_name,
    				cash_name = Cash.cash_name,
                	// cashstatus_name = CashStatus.cashstatus_name,
                	user_name = (Users == null ? "[No Data]" : Users.user_firstname + (Char)32 + Users.user_lastname),
                	cashtransaction_amount = (Cash.cashstatus_id == 2 ? 0.00 : 150.00)
                };
    		
    		foreach(var result in query)
    		{
    			Console.WriteLine(result);
    		}
    	}
    
    	public static List<Cash> _DataTable_Cash = 
    		new List<Cash> { new Cash() };
    	
    	public static List<Cellars> _DataTable_Cellars = 
    		new List<Cellars> { new Cellars() };
    	
    	public static List<CashStatus> _DataTable_CashStatus = 
    		new List<CashStatus> { new CashStatus() };
    	
    	public static List<CashOpeningsAssignments> _DataTable_CashOpeningsAssignments = 
    		new List<CashOpeningsAssignments> { };
    	
    	public static List<Users> _DataTable_Users =
    		new List<Users>() { new Users() };
    }
    
    public class Cash
    {
    	public int cash_id { get; set; }
    	public string cash_name { get; set; }
    	public int cellar_id { get; set; }
    	public int cashstatus_id { get; set; }
    }
    
    public class Cellars
    {
    	public string cellar_name { get; set; }
    	public int cellar_id { get; set; }
    }
    
    public class CashStatus
    {
    	public int cashstatus_id { get; set; }
    	public string cashstatus_name { get; set; }
    }
    
    public class CashOpeningsAssignments
    {
    	public int user_id { get; set; }
    	public int cash_id { get; set; }
    	public int cashopeningassignmentstatus_id { get; set; }
    }
    
    public class Users
    {
    	public string user_firstname { get; set; }
    	public string user_lastname { get; set; }
    	public int user_id { get; set; }
    }
    
