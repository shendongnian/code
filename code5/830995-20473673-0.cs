    public class WorldPosition
    {
        public int X;
        public int Y;
        public int Z;
        public override int GetHashCode()
        {
            int result = X.GetHashCode();
            result = (result * 397) ^ Y.GetHashCode();
            result = (result * 397) ^ Z.GetHashCode();
            return result;
        }
    }
