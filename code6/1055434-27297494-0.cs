    public interface IDeepClonable<T>
    {
        T DeepClone();
    }
    class Foo : IDeepClonable<Foo>
    {
        Foo DeepClone()
        {
            return (T)this.MemberWiseClone();
        }
    }
    class Bar : IDeepClonable<Bar>
    {
        private Foo _foo;
        private List<Foo> _lists;
        Bar DeepClone()
        {
            var clone = (Bar)this.MemberWiseClone();
            
            // This makes sure that deeper references are also cloned.
            clone._foo = _foo.DeepClone();
            // Though you still need to manually clone types that you do not own like lists
            // but you can also turn this into an extension method if you want.
            clone._lists = _lists.Select(f => f.DeepClone()).ToList();
            return clone;
        }
    }
