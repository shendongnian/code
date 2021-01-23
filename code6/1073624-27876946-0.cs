    public static class Extentions
        {
            /// <summary>
            /// Used to find if an local variable aggreation based condition is met in a collection of items.
            /// </summary>
            /// <typeparam name="TItem">Collection items' type.</typeparam>
            /// <typeparam name="TLocal">Local variable's type.</typeparam>
            /// <param name="source">Inspected collection of items.</param>
            /// <param name="initializeLocalVar">Returns local variale initial value.</param>
            /// <param name="changeSeed">Returns desired local variable after each iteration.</param>
            /// <param name="stopCondition">Prediate to stop the method execution if collection hasn't reached last item.</param>
            /// <returns>Was stop condition reached before last item in collection was reached.</returns>
            /// <example> 
            ///  var numbers = new []{1,2,3};
            ///  bool isConditionMet = numbers.CheckForLocalVarAggreatedCondition(
            ///                                             () => 0, // init
            ///                                             (a, i) => i == 1 ? ++a : a, // change local var if condition is met 
            ///                                             (a) => a > 1);   
            /// </example>
            public static bool CheckForLocalVarAggreatedCondition<TItem, TLocal>(
                                    this IEnumerable<TItem> source,
                                    Func<TLocal> initializeLocalVar,
                                    Func<TLocal, TItem, TLocal> changeSeed,
                                    Func<TLocal, bool> stopCondition)
            {
                TLocal local = default(TLocal);
                foreach (TItem item in source)
                {
                    local = changeSeed(local, item);
                    if (stopCondition(local))
                    {
                        return true;
                    }
                }
    
                return false;
            }
        }
