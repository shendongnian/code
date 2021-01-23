	// Make sure to add a using for System.ComponentModel
	void Main()
	{
		Test.First.GetDescription().Dump();
		Test.Second.GetDescription().Dump();
	}
	
	public enum Test
	{
		[Description("My first enum value's description.")]
		First = 1,
		[Description("My second enum value's description.")]
		Second = 2
	}
	
	public static class EnumExtensions
	{
		public static string GetDescription(this Enum value)
		{
			DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			return (descriptionAttributes != null && descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : null);
		}
	}
