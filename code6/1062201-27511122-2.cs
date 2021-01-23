    public interface IMessage { }
    
    public interface Message1 : IMessage { }
    
    
    public class Mop1 : IConsumer<Message1>
    {
    }
    
    public interface IConsumer<out IMessage>
    {
    }
    	
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var list = new List<IConsumer<IMessage>>();
    		var mop = new Mop1();
    
    		list.Add(mop);   // Error occurs here
    	}
    }
