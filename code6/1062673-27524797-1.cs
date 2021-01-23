    class TypeWrapper : Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, SomeType[][]>>>>
    {
        public decimal minimumX()
        {
			Func<Dictionary<int, SomeType[][]>, decimal> inner = (Dictionary<int, SomeType[][]> c) => c.Values
							.Min(d => d
								.Sum(e => e.Sum(f => f.x))
							);
		
            return base.Values
				.Min(a => a.Values
					.Min(b => b.Values
						.Min(inner)
					)
				);
        }
    }
