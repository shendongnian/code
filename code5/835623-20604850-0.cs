    using System;
    
    namespace ConsoleApplication1
    {
    	enum ButtonChanger
    	{
    		Change1 = 1,
    		Change2 = 2,
    		Change3 = 3
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var changer = GetButtonChanger(2);
    
    			Console.WriteLine(changer);
    			Console.WriteLine((int)changer);
    		}
    
    		private static ButtonChanger GetButtonChanger(int i)
    		{
    			return (ButtonChanger)Enum.Parse(typeof(ButtonChanger), string.Format("Change{0}", i));
    		}
    	}
    }
