	class Program
	{
		static void Main(string[] args)
		{
			Queue<OrderClass> orderQueue = new Queue<OrderClass>();
			for (int i = 0; i < 10; i++)
			{
				orderQueue.Enqueue(new OrderClass() { DesiredWeek = (i / 3) });
			}
			outResultNonDestructive(orderQueue);
			outResultDestructive(orderQueue);
			
		}
		public class OrderClass
		{
			public int DesiredWeek { get; set; }
		}
		private static void outResultDestructive(Queue<OrderClass> orderQueue)
		{
			bool last = false;
			int lengthOfQInTheBeginning = orderQueue.Count;
			for (int i = 0; i < lengthOfQInTheBeginning; i++)
			{
				var current = orderQueue.Dequeue();
				if(i >= lengthOfQInTheBeginning - 1)
				{
					last = true;
				}
				else
				{
					var next = orderQueue.Peek();
					if(current.DesiredWeek != next.DesiredWeek)
					{
						last = true;
					}
				}
				if (last)
				{
					//Do work...
					Console.WriteLine(current.DesiredWeek.ToString() + " - Last? " + last.ToString());
					last = false;
				}
				else
				{
					Console.WriteLine(current.DesiredWeek.ToString() + " - Last? " + last.ToString());
				}
			}
		}
		private static void outResultNonDestructive(IEnumerable<OrderClass> orderQueue)
		{
			bool last = false;
			IEnumerator<OrderClass> currentEnumerator = orderQueue.GetEnumerator();
			IEnumerator<OrderClass> nextEnumerator = orderQueue.GetEnumerator();
			if(!nextEnumerator.MoveNext())
			{
				//No elements
			}
			while(currentEnumerator.MoveNext())
			{
				OrderClass next = null;
				if(nextEnumerator.MoveNext())
				{
					next = nextEnumerator.Current;
				}
				var current = currentEnumerator.Current;
				if(next == null || current.DesiredWeek != next.DesiredWeek)
				{
					last = true;
				}
				if (last)
				{
					//Do work...
					Console.WriteLine(current.DesiredWeek.ToString() + " - Last? " + last.ToString());
					last = false;
				}
				else
				{
					Console.WriteLine(current.DesiredWeek.ToString() + " - Last? " + last.ToString());
				}
			}
		}
