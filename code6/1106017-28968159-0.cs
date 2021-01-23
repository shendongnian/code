		public int GetHashCode(SqlGeography obj)
		{
			unchecked
			{
				return ((obj.Lat.GetHashCode() * 397) ^ obj.Long.GetHashCode());
			}
		}
