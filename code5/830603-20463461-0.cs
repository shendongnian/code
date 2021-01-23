	public interface IPosition2F
	{
		float X { get; }
		float Y { get; }
	}
	public class CoordMap<T> where T : IPosition2F
	{
		SortedDictionary<int, List<T>> map = new SortedDictionary<int,List<T>>();
		readonly Func<float, int> xPartition = (x) => (int)Math.Floor(x);
		public void Add(T entry)
		{
			int xpart = xPartition(entry.X);
			List<T> col;
			if (!map.TryGetValue(xpart, out col))
			{
				col = new List<T>();
				map[xpart] = col;
			}
			col.Add(entry);
		}
		public T[] ExtractRange(float left, float top, float right, float bottom)
		{
			var rngLeft = xPartition(left) - 1;
			var rngRight = xPartition(right) + 1;
			var cols =
				from keyval in map
				where keyval.Key >= rngLeft && keyval.Key <= rngRight
				select keyval.Value;
			var cells =
				from cell in cols.SelectMany(c => c)
				where cell.X >= left && cell.X <= right &&
					cell.Y >= top && cell.Y <= bottom
				select cell;
			return cells.ToArray();
		}
		public CoordMap()
		{ }
		// Create instance with custom partition function
		public CoordMap(Func<float, int> partfunc)
		{
			xPartition = partfunc;
		}
	}
