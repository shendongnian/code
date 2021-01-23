    using System;
    using System.Reactive.Linq;
    using System.Threading;
    
    namespace Test
    {
        public class Class
        {
    		public static void Main()
    		{
    			var timeToDoTheThing = new DateTimeOffset(2013, 10, 19, 22, 19, 30, TimeSpan.Zero);
    			Action<long> codeToRun = _ => Console.WriteLine("It is time.");
    			Observable.Timer(timeToDoTheThing).Subscribe(codeToRun);
    
    			Thread.Sleep(100000);
    		}
        }
    }
