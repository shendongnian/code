    class Tile
    {
        internal static void Test(Tile t)
        {
            object mc = t.MemberwiseClone();  // works fine!
        }
    }
    class ThisIsNoTile
    {
        internal static void Test(Tile t)
        {
            object mc = t.MemberwiseClone();  // illegal, will not compile
        }
    }
