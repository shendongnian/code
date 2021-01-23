    using AliasName = System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<string>>;
    namespace Progam1
    {
        class Program
        {
            static void Main()
            {
                var dict1 = new AliasName();
                var dict2 = new AliasName();
    
                CompareDicts(dict1, dict2);
            }
    
            private static void CompareDicts(AliasName dict1, AliasName dict2)
            {
                // Blah blah
            }
    
        }
    }
