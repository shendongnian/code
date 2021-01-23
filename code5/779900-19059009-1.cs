        internal abstract class ErzatsEnumBase {
            protected static readonly ObjectCache Cache = MemoryCache.Default;
            protected ErzatsEnumBase ( string CacheKey, CacheItemPolicy CachePolicy ) {
                Cache.Add ( CacheKey, this, CachePolicy, null );
            }
        }
        public sealed class ErzatsEnum: ErzatsEnumBase {
            private static CacheItemPolicy policy = new CacheItemPolicy () {
                AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration,
                SlidingExpiration = new TimeSpan ( 0, 15, 0 )
            };
            private ErzatsEnum ( string CacheKey )
                : base ( CacheKey, policy ) {
            }
            public ErzatsEnum Instance1 {
                get {
                    ErzatsEnum result = ErzatsEnumBase.Cache.Get ( "Instance1" );
                    if ( result == null )
                       result = new ErzatsEnum ( "Instance1" );
                    return result;
                }
            }
            public ErzatsEnum Instance2 {
                get {
                    ErzatsEnum result = ErzatsEnumBase.Cache.Get ( "Instance2" );
                    if ( result == null )
                       result = new ErzatsEnum ( "Instance2" );
                    return result;
                }
            }
        }
