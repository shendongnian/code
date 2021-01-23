    public class abc
    {
    	private enum Column
    	{
    		ID = 1,
    		Date = 2,
    		jobtype = 3,
    		command = 4
    	}
    	
    	public abc(SqlDataReader reader)
    	{
    		ID = sdr.GetFieldValue<int>[Column.ID];
    		Date = sdr.GetFieldValue<string>[Column.Date];
    		jobtype = sdr.GetFieldValue<string>[Column.jobtype];
    		command = sdr.GetFieldValue<string>[Column.command];
    		
    		// or
    		//ID = (int)sdr["ID"];
    		//Date = (string)sdr["Date"];
    		//jobtype =(string)sdr["jobtype"];
    		//command = (string)sdr["command"];
    	}
    
    	public int ID { get; set; }
    	public string Date { get; set; }
    	public string jobtype { get; set; }
    	public string command { get; set; }
    }
