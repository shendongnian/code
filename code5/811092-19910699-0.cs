    namespace ClassLibrary1
    {
    	internal class ClassLibrary1_AnonObj1
    	{
    		public int ID { get; set; }
    		public string Name { get; set; }
    	}
    	
    	public class Class1
    	{
    		public object dyn()
    		{
    		    var obj = new ClassLibrary1_AnonObj1 { ID = 2, Name = "Rajesh" };
    		    return obj;
    		}
    	}
    }
    
    namespace ConsoleApplication2
    {
    	internal class ClassLibrary2_AnonObj2
    	{
    		public int ID { get; set; }
    		public string Name { get; set; }
    	}
    	
        public class Program
        {
            public static void Main(string[] args)
            {
                Program objPgm = new Program();
                Class1 objCls=new Class1();            
                object obj = objCls.dyn();
                var list = objPgm.cast(obj, new ClassLibrary2_AnonObj2 { ID = 0, Name = "" });
            }
    
            public  T cast<T>(object obj,T type) 
            {          
                return (T)obj; 
            }
        }
    }
