	// simple class for the example
	public class DataHolder
	{
		private int a;
		
		[MaxValue(10)]
		public int A 
		{ 
			get
			{
				var memberInfo = this.GetType().GetMember("A");
				if (memberInfo.Length > 0)
				{
					// name of property could be retrieved via reflection
					var mia = this.GetType().GetMember("A")[0];
					var attributes = System.Attribute.GetCustomAttributes(mia);
					if (attributes.Length > 0)
					{
						// TODO: iterate over all attributes and check attribute name
						var maxValueAttribute = (MaxValue)attributes[0];
						if (a > maxValueAttribute.Max) { a = maxValueAttribute.Max; }
					}
				}
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
