	class Program
	{
		static void Main( string[] args ) { new Program(); }
		public Program()
		{
			var list = new int[] { 1, 2, 3, 4, 5 };
			int total = list
				.Aggregate( new Accumulator( 0 ), ( a, i ) => a.Next( i ), a => a.Total );
		}
	}
	class Accumulator
	{
		public Accumulator( int total )
		{
			this.total = total;
		}
		public Accumulator Next( int i )
		{
			if ( isDone )
				return this;
			else {
				int total = this.total + i;
				if ( total < 12 )
					return new Accumulator( total );
				else {
					isDone = true;
					return this;
				}
			}
		}
		bool isDone;
		public int Total
		{
			get { return total; }
		}
		readonly int total;
	}
