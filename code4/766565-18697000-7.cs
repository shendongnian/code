    public class HashPiece
    {
        public readonly long Hash64;
        public readonly Piece[] Board = new Piece[64];
        
        public int GetHashCode()
        {
             return Hash64.GetHashCode();
        }
        public bool Equals(object other)
        {
            return this.Hash64 == ((HashPiece)other).Hash64;
        }
    }
