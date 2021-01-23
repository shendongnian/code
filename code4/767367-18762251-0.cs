    public enum Status
    {
        Nothing = 0,
        Insert,
        Delete,
        Edit
    }
    public abstract class Searchable
    {
        public virtual Guid Id { get; set; }
        public virtual Status Status { get; set; }
        protected internal abstract IEnumerable SearchableProperties { get; }
    }
    public class ClassA : Searchable
    {
        public string Text { get; set; }
        public int Number { get; set; }
        protected internal override IEnumerable SearchableProperties
        {
            get
            {
                yield return Text;
                yield return Number;
            }
        }
    }
    public class ClassB : Searchable
    {
        public string Text { get; set; }
        public Image Pic { get; set; }
        protected internal override IEnumerable SearchableProperties
        {
            get
            {
                yield return Text;
                yield return Pic;
            }
        }
    }
    public class ClassC : Searchable
    {
        public byte[] Data { get; set; }
        public DateTime Date { get; set; }
        protected internal override IEnumerable SearchableProperties
        {
            get
            {
                yield return Data;
                yield return Date;
            }
        }
    }
