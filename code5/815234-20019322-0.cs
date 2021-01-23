	// simple class for the example
	public class DataHolder
	{
		private int a;
		
		[MaxValue(10)]
		public int A 
		{ 
			get
			{
				var maxAttribute = (MaxValue)System.Attribute.GetCustomAttributes(this.GetType().GetMember("A")[0])[0];
				if (a > maxAttribute.Max) { a = maxAttribute.Max; }
				return a;
			}
			set
			{
				a = value;
			}
		}
	}
	// max attribute
	public class MaxValue : Attribute
	{
		public int Max;
		
		public MaxValue(int max)
		{
			Max = max;	
		}
	}
