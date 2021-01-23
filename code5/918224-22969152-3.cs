    public interface ISequence
    {
        int SequenceNumber { get; set; }
        
    }
    class Item : ISequence
    {
        public int SequenceNumber { get; set; }
        public Item(int number)
        {
            SequenceNumber = number;
        }
    }
