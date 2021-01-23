    // JoinExtensions: Created 07/12/2014 - Johnny Olsa
    
    using System.Linq;
    
    namespace System.Collections.Generic
    {
        /// <summary>
        /// Join Extensions that .NET should have provided?
        /// </summary>
        public static class JoinExtensions
        {
            /// <summary>
            /// Correlates the elements of two sequences based on matching keys. A specified
            /// System.Collections.Generic.IEqualityComparer&lt;T&gt; is used to compare keys.
            /// </summary>
            /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
            /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
            /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
            /// <typeparam name="TResult">The type of the result elements.</typeparam>
            /// <param name="outer">The first sequence to join.</param>
            /// <param name="inner">The sequence to join to the first sequence.</param>
            /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
            /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
            /// <param name="resultSelector">A function to create a result element from two combined elements.</param>
            /// <param name="comparer">A System.Collections.Generic.IEqualityComparer&lt;T&gt; to hash and compare keys.</param>
            /// <returns>
            /// An System.Collections.Generic.IEnumerable&lt;T&gt; that has elements of type TResult
            /// that are obtained by performing an left outer join on two sequences.
            /// </returns>
            /// <example>
            /// Example:
            /// <code>
            /// class TestClass
            /// {
            ///        static int Main()
            ///        {
            ///            var strings1 = new string[] { "1", "2", "3", "4", "a" };
            ///            var strings2 = new string[] { "1", "2", "3", "16", "A" };
            ///            
            ///            var lj = strings1.LeftJoin(
            ///                strings2,
            ///                a => a,
            ///                b => b,
            ///                (a, b) => (a ?? "null") + "-" + (b ?? "null"),
            ///                StringComparer.OrdinalIgnoreCase)
            ///                .ToList();
            ///        }
            ///    }
            ///    </code>
            /// </example>
            public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
                Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
            {
                return outer.GroupJoin(
                    inner,
                    outerKeySelector,
                    innerKeySelector,
                    (o, ei) => ei
                        .Select(i => resultSelector(o, i))
                        .DefaultIfEmpty(resultSelector(o, default(TInner))), comparer)
                        .SelectMany(oi => oi);
            }
    
            /// <summary>
            /// Correlates the elements of two sequences based on matching keys. The default
            /// equality comparer is used to compare keys.
            /// </summary>
            /// <typeparam name="TOuter">The type of the elements of the first sequence.</typeparam>
            /// <typeparam name="TInner">The type of the elements of the second sequence.</typeparam>
            /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
            /// <typeparam name="TResult">The type of the result elements.</typeparam>
            /// <param name="outer">The first sequence to join.</param>
            /// <param name="inner">The sequence to join to the first sequence.</param>
            /// <param name="outerKeySelector">A function to extract the join key from each element of the first sequence.</param>
            /// <param name="innerKeySelector">A function to extract the join key from each element of the second sequence.</param>
            /// <param name="resultSelector">A function to create a result element from two combined elements.</param>
            /// <returns>
            /// An System.Collections.Generic.IEnumerable&lt;T&gt; that has elements of type TResult
            /// that are obtained by performing an left outer join on two sequences.
            /// </returns>
            /// <example>
            /// Example:
            /// <code>
            /// class TestClass
            /// {
            ///        static int Main()
            ///        {
            ///            var strings1 = new string[] { "1", "2", "3", "4", "a" };
            ///            var strings2 = new string[] { "1", "2", "3", "16", "A" };
            ///            
            ///            var lj = strings1.LeftJoin(
            ///                strings2,
            ///                a => a,
            ///                b => b,
            ///                (a, b) => (a ?? "null") + "-" + (b ?? "null"))
            ///                .ToList();
            ///        }
            ///    }
            ///    </code>
            /// </example>
            public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
                Func<TOuter, TInner, TResult> resultSelector)
            {
                return outer.LeftJoin(inner, outerKeySelector, innerKeySelector, resultSelector, default(IEqualityComparer<TKey>));
            }
    
        }
    }
