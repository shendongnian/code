    public class Node
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [InverseProperty("A")]
        public virtual ObservableCollection<Relationship> Outgoing { get; set; }
        [InverseProperty("B")]
        public virtual ObservableCollection<Relationship> Incoming { get; set; }
    }
