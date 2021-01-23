	using System;
						
	public class Program
	{
		public static void Main()
		{		
			var my = new MyClass();
			my.MyAction = msg => Console.WriteLine(msg);
			my.MyAction("asdf");
			
			my.MyEvent += (s, e) => Console.WriteLine("Event");
			my.InvokeEvent();
		}
		
		public class MyClass {
			public Action<string> MyAction { get; set; }
	
			public event EventHandler MyEvent;
	
			public void InvokeEvent() {
				// the MyEvent can be called only within the MyClass			
				MyEvent(this, null);
			}
		}
	}  
