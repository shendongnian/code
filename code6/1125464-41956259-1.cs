        public static class Statistics
	    {		
		    internal class ExtremumAccumulator
		    {
			    internal double Min;
			    internal double Max;
		    }
		
		   /// <summary>
		   /// An aggregate parallel query to return the minimum and the maximum of <paramref name="data"/> together, faster than two successive parallel queries to minimum and maximum.
		   /// </summary>
		   /// <param name="data">The list whose extrema we are to find.</param>
		   /// <returns>A <see cref="Tuple{double, double}"/> instance whose <see cref="Tuple{double, double}.Item1"/> represents the minimum and whose <see cref="Tuple{double, double}.Item2"/> contains the maximum of <paramref name="data"/>.</returns>
		   public static Tuple<double, double> Extrema(this IList<double> data)
		   {
			   ParallelQuery<double> query = data.AsParallel();
			
			   return query.Aggregate(
				  // Initialise accumulator:
				  () => new ExtremumAccumulator() { Min = Double.MaxValue, Max = Double.MinValue },
				  // Aggregate calculations:
				  (accumulator, item) => { if (item < accumulator.Min) accumulator.Min = item; if (item > accumulator.Max) accumulator.Max = item; return accumulator; },
				  // Combine accumulators:
				  (accumulator1, accumulator2) => new ExtremumAccumulator() { Min = Math.Min(accumulator1.Min, accumulator2.Min), Max = Math.Max(accumulator1.Max, accumulator2.Max) },
				  // Get result:
				  accumulator => new Tuple<double, double>(accumulator.Min, accumulator.Max)
			  );
		   }
       }
