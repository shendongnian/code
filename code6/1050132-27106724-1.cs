    public class Hash
    {
        private readonly int hashCode;
        public Hash(int hashCode)
        {
            this.hashCode = hashCode;
        }
        public override int GetHashCode()
        {
            return this.hashCode;
        }
    }
