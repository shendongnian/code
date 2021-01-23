    class TypeWrapper : Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, SomeType[][]>>>>
    {
        public decimal minimumX()
        {
            return base.Values
				.Min<Dictionary<int, Dictionary<int, Dictionary<int, SomeType[][]>>>, decimal>(a => a.Values
					.Min<Dictionary<int, Dictionary<int, SomeType[][]>>, decimal>(b => b.Values
						.Min<Dictionary<int, SomeType[][]>, decimal>(c => c.Values
							.Min(d => d
								.Sum(e => e.Sum(f => f.x))
							)
						)
					)
				);
        }
    }
