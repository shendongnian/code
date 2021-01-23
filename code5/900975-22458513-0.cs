    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace SO7
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			Console.WriteLine("Hello World!");
    			
    			LogicList<int> intBasedLogicalList = new LogicList<int>(new Func<int, bool>[] {x => x<3, x => x <5, x => x<8});
    			Console.WriteLine(intBasedLogicalList.And(2));
    			Console.WriteLine(intBasedLogicalList.And(4));
    			Console.WriteLine(intBasedLogicalList.Or(7));
    			Console.WriteLine(intBasedLogicalList.Or(8));
    			
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    	}
    	
    	public class LogicList<T> : List<Func<T, bool>>
    	{
    		
    		private List<Func<T,bool>> _tests;
    		
    		public LogicList(IEnumerable<Func<T, bool>> tests)
    		{
    			_tests = new List<Func<T, bool>>();
    			foreach(var test in tests)
    			{
    				_tests.Add(test);
    			}
    		}
    		
    		public bool And(T argument){
    			foreach(var test in _tests)
    			{
    				if (!test(argument)){
    					return false;
    				}
    			}
    			return true;
    		}
    		
    		public bool Or(T argument){
    			return _tests.Any(x => x(argument));
    			
    		}
    		
    	}
    	
    }
