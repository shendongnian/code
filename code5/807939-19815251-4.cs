    public class FluentMatcher<T1, T2, TResult>
    {
        /*
           Methods A B C
    
         */
    
        public FluentMatcherWithElse<T1, T2, TResult> Else(TResult resultIfElseRequired)
        {
            return new FluentMatcherWithElse(resultIfElseRequired);
        }
    }
    
    public class FluentMatcherWithElse<T1, T2, TResult>
    {
        internal FluentMatcherWithElse(TResult resultIfElseRequired) { ... }
    
        /*
           Methods A B C - but NO else method
    
         */
    }
