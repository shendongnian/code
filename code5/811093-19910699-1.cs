    namespace ClassLibrary1
    {
    	public class MyInfo
    	{
    		public int ID { get; set; }
    		public string Name { get; set; }
    	}
    	
    	public class Class1
    	{
    		public MyInfo dyn()
    		{
    		    var obj = new MyInfo { ID = 2, Name = "Rajesh" };
    		    return obj;
    		}
    	}
    }
    
    namespace ConsoleApplication2
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Program objPgm = new Program();
                Class1 objCls=new Class1();            
                MyInfo obj = objCls.dyn();
            }
        }
    }
