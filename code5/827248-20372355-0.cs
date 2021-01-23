	public static class Extensions {
		public static string MyCustomAggregateFunction(this IGrouping<int,TaxType> source, Func<TaxType,string> selector) {
			// blah-blah-blah
			//return something
		}
	}
