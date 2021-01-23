    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReflectOnSerializableAttr
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			//use Linq
    			var q = from t in Assembly.GetExecutingAssembly().GetTypes()
    					where t.IsClass &&  ((t.Attributes & TypeAttributes.Serializable) != TypeAttributes.Serializable)
    					select t;
    			q.ToList().ForEach(t => Console.WriteLine(t.Name));
    
    			Console.ReadKey();
    		}
       	}
    	[Serializable]
    	public class TestSerializableOne
    	{
    		public string SomeFunc() { return "somefunc"; }
    	}
    
    	public class TestForgotSerializable
    	{
    		private int _testInt = 200;
    	}
    }
