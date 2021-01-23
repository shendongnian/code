    public class TilePositionCompare : IEqualityComparer<TilePosition>
    {
        public bool Equals(TilePosition tileA, TilePosition tileB)
        {
            return tileA.PosX == tileB.PosX && tileA.PosY == tileB.PosY;
        }
    
        public int GetHashCode(TilePosition tile)
        {
            var hash = 17;
            hash = hash * 23 + tile.PosX.GetHashCode();
            hash = hash * 23 + tile.PosY.GetHashCode();
            return hash;
        }
    }
