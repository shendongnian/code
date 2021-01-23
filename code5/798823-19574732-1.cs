        public static IEnumerable<IEnumerable<T>> Subsequencise<T>(this IEnumerable<T> input, int subsequenceLength)
        {
            var enumerator = input.GetEnumerator();
            SubsequenciseParameter parameter = new SubsequenciseParameter { Next = enumerator.MoveNext() };
            while (parameter.Next)
                yield return getSubSequence(enumerator, subsequenceLength, parameter);
            
        }
        private static IEnumerable<T> getSubSequence<T>(IEnumerator<T> enumerator, int subsequenceLength, SubsequenciseParameter parameter)
        {
            do
            {
                yield return enumerator.Current;
            } while ((parameter.Next = enumerator.MoveNext()) && --subsequenceLength > 0);
        } 
        
        // Needed to let the Subsequencisemethod know when to stop, since you cant use out or ref parameters in an yield-return method.
        class SubsequenciseParameter
        {
            public bool Next { get; set; }
        }
