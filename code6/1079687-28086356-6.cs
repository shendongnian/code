    public class Colleague : Person
    {
        // don't need any other properties based on what you've posted
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Colleague> Colleagues { get; set; }
    }
