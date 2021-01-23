    public static Mapper( )
    {
        private static Dictionary<MapTuple, object> _maps = new Dictionary<MapTuple, object>();
        
        public static void AddMap<TFrom, TTo>(Action<TFrom, TTo, DateTime> map)
        {
            Mapper._maps.Add(MapTuple.Create(typeof(TFrom), typeof(TTo)), map);
        }
        public static TTo Map<TFrom, TTo>( TFrom srcObj )
        {
            var typeFrom = typeof(TFrom);
            var typeTo = typeof(TTo);
            var key = MapTuple.Create(typeFrom, typeTo);
            var map = (Action<TFrom, TTo, DateTime>) Mapper._maps[key];
            TTo targetObj = new TTo( );
            map( srcObj, targetObj );
            return targetObj;
        }
