	public static class MyExtensions
	{
		public static SelectList ToSelectList<TEnum>(this TEnum obj) 
			where TEnum : struct, IComparable, IFormattable, IConvertible // correct one
		{
	    	var items = Enum.GetValues(typeof (TEnum))
				    .OfType<Enum>()
				    .Select(x => new { Text = Enum.GetName(typeof (TEnum), x) })
				    .Select(x => new SelectListItem
			        {
			            Text = x.Text, 
				        Value = x.Text
					});
				
			return new SelectList(items, "Value", "Text");
		}
	}
