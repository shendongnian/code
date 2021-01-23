    public class MyRepository
    {		
		 public CommandMessage DeQueueTestProject()
		 {
		    using (var dc = new TestProjectLinqSQLDataContext())
        	{
		 		var results = dc.usp_dequeueTestProject().Select(c => new CommandMessages(c.Command_Type, c.Command, c.DateTimeSent)).FirstOrDefault();
				return results;
			}
		 }
    }
