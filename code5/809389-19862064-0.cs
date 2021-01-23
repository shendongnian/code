    public class Example
    {
        public int ID { get; set; }
        public override bool Equals(object obj)
        {
            return this.ID == (obj as Example).ID;
        }
    }
