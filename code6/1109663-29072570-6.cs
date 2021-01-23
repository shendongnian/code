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
			Values.Add(new SomeValue { Date = this, Id = id, Status = status, StatusNumber = statusNumber });
		}
		public IEnumerable<Tuple<SomeValue, SomeValue>> GetDifference(DateOfValues other)
		{
			var notMatching = Values.Except(other.Values, new SomeValueComparer())
				.Union(other.Values.Except(Values,new SomeValueComparer()));
			return notMatching
				.GroupBy(x => x.Id)
				.Select(x =>
					new Tuple<SomeValue, SomeValue>(
						x.FirstOrDefault(y => y.Date == this), x.FirstOrDefault(y => y.Date == other)));
		}
	}
	public class SomeValueComparer : IEqualityComparer<SomeValue>
	{
		public bool Equals(SomeValue x, SomeValue y)
		{
			return 
				x.Id == y.Id &&
				x.Status == y.Status &&
			    x.StatusNumber == y.StatusNumber;
		}
		public int GetHashCode(SomeValue obj)
		{
			return obj.GetHashCode();
		}
	}
	public class SomeValue
	{
		public int Id { get; set; }
		public DateOfValues Date { get; set; }
		public string Status { get; set; }
		public decimal StatusNumber { get; set; }
		
		public override int GetHashCode()
		{
			return string.Format("{0}{1}{2}",Id,Status,StatusNumber).GetHashCode();
		}
	}
