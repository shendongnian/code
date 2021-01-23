	class Program
	{
		static void Main(string[] args)
		{
			// Test
			DateOfValues dov1 = new DateOfValues { Id = 1, Start = new DateTime(2011, 12, 01) };
			dov1.AddSomeValue(1,"OK",2);
			dov1.AddSomeValue(2,"Not OK",3);
			dov1.AddSomeValue(3,"Not OK",4);
			dov1.AddSomeValue(4,"Additional dov1",5);
			DateOfValues dov2 = new DateOfValues { Id = 1, Start = new DateTime(2011, 12, 02) };
			dov2.AddSomeValue(1, "OK", 2);
			dov2.AddSomeValue(2, "Not OK", 4);
			dov2.AddSomeValue(3, "OK", 1);
			dov2.AddSomeValue(6, "Additional dov1", 15);
			foreach (Tuple<SomeValue,SomeValue> difference in dov1.GetDifference(dov2))
			{
				if (difference.Item1 != null)
				{
					Console.WriteLine("Item1: Id:{0}; Status:{1}; Status Number:{2}",
						difference.Item1.Id, difference.Item1.Status, difference.Item1.StatusNumber);
				}
				if (difference.Item2 != null)
				{
					Console.WriteLine("Item2: Id:{0}; Status:{1}; Status Number:{2}",
						difference.Item2.Id, difference.Item2.Status, difference.Item2.StatusNumber);
				}
				Console.WriteLine("-------------------------------------------");
			}
		}
	}
	public class DateOfValues
	{
		public DateOfValues()
		{
			Values = new Collection<SomeValue>();
		}
		public int Id { get; set; }
		public DateTime Start { get; set; }
		public Collection<SomeValue> Values;
		public void AddSomeValue(int id, string status, decimal statusNumber)
		{
			Values.Add(new SomeValue{Date = this,Id = id,Status = status,StatusNumber = statusNumber});
		}
		public IEnumerable<Tuple<SomeValue, SomeValue>> GetDifference(DateOfValues other)
		{
			IEnumerable<SomeValue> notMatching = Values.Where(v => !other.Values.Any(o => v.Equals(o)))
				.Union(other.Values.Where(v=> !Values.Any(o=> v.Equals(o)))).Distinct();
			return notMatching
				.GroupBy(x => x.Id)
				.Select(x => 
					new Tuple<SomeValue, SomeValue>(
						x.FirstOrDefault(y => y.Date == this), x.FirstOrDefault(y => y.Date == other)));
		}
	}
	public class SomeValue : IEquatable<SomeValue>
	{
		public int Id { get; set; }
		public DateOfValues Date { get; set; }
		public string Status { get; set; }
		public decimal StatusNumber { get; set; }
		public bool Equals(SomeValue other)
		{
			return other.Id == Id && other.Status == Status && other.StatusNumber == StatusNumber;
		}
	}
