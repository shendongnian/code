    public class Program
    {
        public static void Main( string[] args )
        {
            var idiots = new List<Idiot>
            {
                new Idiot { Weapons = new[] { new Weapon { Damage = 10 }, new Weapon { Damage = 20 } } },
                new Idiot { Weapons = new[] { new Weapon { Damage = 6 }, new Weapon { Damage = 100 } } },
                new Idiot { Weapons = new[] { new Weapon { Damage = 45 }, new Weapon { Damage = 12 } } },
                new Idiot { Weapons = new[] { new Weapon { Damage = 24 }, new Weapon { Damage = 5 } } },
            };
    
            foreach ( var i in idiots )
                i.Weapons.QuickSort( 0, i.Weapons.Count() - 1, ( a, b ) => a.Damage.CompareTo( b.Damage ) );
    
            //Solution using IEnumerable{T} extension methods
            idiots.ForEach( x => x.Weapons = x.Weapons.OrderBy( y => y.Damage ).ToArray() );
        }
    }
    
    public static class Ex
    {
        public static void QuickSort<T>(this IEnumerable<T> input, int low, int high, Func<T, T, Int32> comparer)
        {
            input
                .ToList()
                .Sort( low, high, new FunctionalComparer<T>( comparer ) );
        }
    }
    
    public class FunctionalComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, Int32> comparer;
    
        public FunctionalComparer(Func<T, T, Int32> comparer)
        {
            this.comparer = comparer;
        }
    
        public Int32 Compare(T x, T y)
        {
            return comparer( x, y );
        }
    
        public static IComparer<T> Create(Func<T, T, Int32> comparer)
        {
            return new FunctionalComparer<T>( comparer );
        }
    }
    
    public class Idiot
    {
        public Weapon[] Weapons { get; set; }
    }
    
    public class Weapon
    {
        public Int32 Damage { get; set; }
    }
