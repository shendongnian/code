	class Program
	{
		static void Main(string[] args)
		{
			var testData = new List<TimeInterval>
			               {
				               new TimeInterval(new DateTime(2015, 02, 02), new DateTime(2015, 03, 02), 1),
							   new TimeInterval(new DateTime(2015, 03, 02), new DateTime(2015, 04, 02), 1),
							   new TimeInterval(new DateTime(2015, 04, 02), new DateTime(2015, 05, 02), 2),
							   new TimeInterval(new DateTime(2015, 05, 02), new DateTime(2015, 06, 02), 2),
							   new TimeInterval(new DateTime(2015, 06, 02), new DateTime(2015, 07, 02), 2),
							   new TimeInterval(new DateTime(2015, 07, 02), new DateTime(2015, 07, 02), 1),
			               };
			var result = FindRanges(testData);
			foreach (var item in result)
			{
				Console.WriteLine("Start: {0} End: {1} Value: {2}",item.StartDate,item.FinishDate,item.Value);
			}
		}
		public static List<TimeInterval> FindRanges(List<TimeInterval> rp)
		{
			List<TimeInterval> timeintervals = new List<TimeInterval>();
			Boolean stop = false;
			DateTime intervalStart = DateTime.Now;
			DateTime intervalFinish = DateTime.Now;
			dynamic value = 0;
			for (int i = 0; i <= rp.Count - 1; i++)
			{
				if (!stop)
				{
					intervalStart = rp[i].StartDate;
					intervalFinish = rp[i].FinishDate; //we might need to put in the startdate here aswell
					value = rp[i].Value;
					stop = true;
				}
				if (i < rp.Count - 1  && Convert.ToDouble("0" + rp[i].Value) == Convert.ToDouble("0" + rp[i + 1].Value))
				{
					//value = rp[i].Value;
					intervalFinish = rp[i+1].FinishDate; //we might need to put in the startdate here aswell
				}
				else //we found an interval so we construct one
				{
					stop = false;
					if (Convert.ToDouble("0" + value) != 0)
					{
						TimeInterval t = new TimeInterval(intervalStart, intervalFinish, value);
						timeintervals.Add(t);
					}
				}
			}
			return timeintervals;
		}
	}
	internal class TimeInterval
	{
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public int Value { get; set; }
		public TimeInterval(DateTime startIn, DateTime finishIn, int valueIn)
		{
			StartDate = startIn;
			FinishDate = finishIn;
			Value = valueIn;
		}
	}
