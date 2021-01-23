    public class MyClass
    {    
        [PropertyComparisonValidator("Last", ComparisonOperator.LessThan, Ruleset="Default")]
        public int First
        {
            [...]
        }
    
        [PropertyComparisonValidator("First", ComparisonOperator.GreaterThan, Ruleset="Default")]
        public int Last
        {
           [...]
        }
    }
