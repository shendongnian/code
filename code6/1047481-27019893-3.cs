    public class IDs
    {
        public int FirstId { get; private set; }
        public int SecondId { get; private set; }
        private IDs() { }
        public IDs(int firstId, int secondId)
        {
            FirstId = firstId;
            SecondId = secondId;
        }
        public override string ToString()
        {
            return string.Format("{0}_{1}", FirstId, SecondId);
        }
    }
