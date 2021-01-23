        public static IEnumerable<string> GetOrderCombinations( string me )
        {
            string looped = me + me;
            return Enumerable
                   .Range(0,me.Length)
                   .SelectMany( x => Enumerable.Range(1,me.Length) , looped.Substring )
                   ;
        }
