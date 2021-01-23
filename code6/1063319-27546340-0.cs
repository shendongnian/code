    public struct GameObjectCoordinate : IEquatable<GameObjectCoordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Equals(GameObjectCoordinate other)
        {
            return X == other.X && Y == other.Y;
        }
        public override bool Equals(object obj)
        {
            return obj is GameObjectCoordinate && Equals((GameObjectCoordinate)obj);
        }
        public override int GetHashCode()
        {
            /* There's a speed advantage in something simple like
            unchecked
            {
                return (X << 16 | X >> 16) ^ Y; 
            }
            and a distribution advantage in the code here. It can be worth
            trying both, but be aware that the code commented out here is better
            at small well-spread key values, and that below at large numbers of
            values especially if many are similar, so do any testing with real
            values your application will deal with.
            */  
            unchecked
            {
                ulong c = 0xDEADBEEFDEADBEEF + ((ulong)X << 32) + (ulong)Y;
                ulong d = 0xE2ADBEEFDEADBEEF ^ c;
                ulong a = d += c = c << 15 | c >> -15;
                ulong b = a += d = d << 52 | d >> -52;
                c ^= b += a = a << 26 | a >> -26;
                d ^= c += b = b << 51 | b >> -51;
                a ^= d += c = c << 28 | c >> -28;
                b ^= a += d = d << 9 | d >> -9;
                c ^= b += a = a << 47 | a >> -47;
                d ^= c += b << 54 | b >> -54;
                a ^= d += c << 32 | c >> 32;
                a += d << 25 | d >> -25;
                return (int)(a >> 1);
            }
        }
        Dictionary<GameObjectCoordinate, GameObject> gameObjects = new Dictionary<GameObjectCoordinate, GameObject>();
