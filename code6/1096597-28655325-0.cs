    using System;
    using System.Collections.Generic;
    using System.Linq;
 
    public class Test
    {
        public static void Main()
        {
            var list = new[] {2, 2, 2, 3, 3, 4, 4, 4, 4};
            // tuples is a list of Tuple<current value, number of repetitions of value>
            var tuples = new List<Tuple<int, int>>();
            var currentTuple = Tuple.Create(0, 0);
            foreach ( var value in list )
            {
                bool newValue = value != currentTuple.Item1;
                if ( newValue && currentTuple.Item2 != 0 )
                   tuples.Add(currentTuple);
                currentTuple = Tuple.Create(
                    value,
                    newValue ? 1 : currentTuple.Item2 + 1);
            }
            tuples.Add(currentTuple);
            var result = new List<int>();
            foreach ( var tuple in tuples )
                result.AddRange(Enumerable.Repeat(tuple.Item2 > 2 ? 0 : tuple.Item1, tuple.Item2));
            foreach ( var item in result )
                Console.WriteLine(item);
        }
    }
