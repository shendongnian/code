    public interface IFriendKey { object Id {get; set;} }
    
    class Friend<TFriend>
    {
    	protected void FriendAssert(IFriendKey key)
    	{
    		if ( key == null || key.Id == null || key.Id.GetType() != typeof(TFriend) )
    			throw new Exception("No right to execute the called method.");
    	}
    }
    
    class A : Friend<B>
    {
    	public void f(IFriendKey key)
    	{
    		FriendAssert(key);
    		Console.WriteLine("ONLY class B can execute this method successfully, even though it is declared public.");
    	}
    }
    
    class B
    {
    	private class AFriendKey : IFriendKey 
    	{
    		public object Id {get; set;}
    	}
    	
    	IFriendKey Key { get { return new AFriendKey() {Id = this}; } }
    	
    	public void g()
    	{
    		new A().f(this.Key); 
    	}
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		new B().g();
    	}
    }
