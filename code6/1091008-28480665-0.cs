    public class Note
    {
    	//Node properties
    }
    
    public class AuditTrail
    {
    	//Audit trail properties
    }
    
    public interface IAuditable
    {
    	AuditTrail AuditTrail { get; set; }
    }
    
    public interface IHaveNotes
    {
    	IList<Note> Notes { get; set; }
    }
    
    public class SomeModel : IAuditable, IHaveNotes
    {
    	public IList<Note> Notes { get; set; }
    	public AuditTrail AuditTrail { get; set; }
    	
    	public SomeModel()
    	{
    		Notes = new List<Note>();
    	}
    }
    
    public class AuditRepository : IRepository<T> where T : IAuditable
    {
    	private IRepository<T> _decorated;
    	public AuditRepository(IRepository<T> decorated)
    	{
    		_decorated = decorated;
    	}
    	
    	public T Find(int id)
    	{
    		var model = _decorated.Find(id);
    		model.Audit = //Access database to get audit
    		
    		return model;
    	}
    	
    	//Other methods
    }
    
    public class NoteRepository : IRepository<T>  where T : IHaveNotes
    {	
    	private IRepository<T> _decorated;
    	public NoteRepository(IRepository<T> decorated)
    	{
    		_decorated = decorated;
    	}
    	
    	public T Find(int id)
    	{
    		var model = _decorated.Find(id);
    		model.Notes = //Access database to get notes
    		
    		return model;
    	}
    	
    	//Other methods
    }
