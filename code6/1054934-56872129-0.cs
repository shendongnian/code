    public class Word : IEntity
    {
        public virtual int WordID { get; set; }
        public virtual string WordText { get; set; }
        public virtual string Pronunciation { get; set; }
    }
