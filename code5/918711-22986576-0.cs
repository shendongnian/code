    void Main()
    {
    	new SubClass("somekey");
    }
    
    public class BaseClass
    {
        public BaseClass(string Value1, string Value2)
        {
            Console.WriteLine (Value1 + "\t" + Value2);
        }
    }
    public class SubClass : BaseClass
    {
        public SubClass(string Key) : base(Key, Decrypt(Key))
        {
            
        }
    	
    	static string Decrypt(string val){
    		return val + "_decrypted";
    	}
    }
