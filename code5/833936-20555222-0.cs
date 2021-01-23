    public interface IFoo
    {
        IEnumerable<IBar> Bars { get; }
    }
    public class Foo : IFoo
    {
        public virtual ICollection<Bar> Bars { get; set; }
        IEnumerable<IBar> IFoo.Bars
        {
           return this.Bars;
        } 
    }
