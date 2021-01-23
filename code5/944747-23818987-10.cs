    public class RealDataRepository: IDataRepository
    {
        readonly MyProjectDataContext _dc;
    	public RealDataRepository()
    	{
    	    _dc = new MyProjectDataContext(); //or however you do it.
    	}
    	
    	public CommandMessages DequeueTestProject()
    	{
    		var command = dc.usp_dequeueTestProject();
            result = command.Select(c => new CommandMessages(c.Command_Type, c.Command, c.DateTimeSent)).FirstOrDefault();
            return result;
    	}
    }
