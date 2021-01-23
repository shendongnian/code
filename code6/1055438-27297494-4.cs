    public interface IDeepCloneable<T>
    {
        T DeepClone();
    }
    class Foo : IDeepCloneable<Foo>
    {
        Foo DeepClone()
        {
            // The simplest usecase
            return (Foo)this.MemberWiseClone();
        }
    }
    class Bar : IDeepCloneable<Bar>
    {
        private Foo _foo;
        private List<Foo> _lists;
        private List<int> _valueTypedLists;
        Bar DeepClone()
        {
            var clone = (Bar)this.MemberWiseClone();
            
            // This makes sure that deeper references are also cloned.
            clone._foo = _foo.DeepClone();
            // Though you still need to manually clone types that you do not own like
            // lists but you can also turn this into an extension method if you want.
            clone._lists = _lists.Select(f => f.DeepClone()).ToList();
            // And you can simply call the ToList/ToArray method for lists/arrays
            // of value type entities.
            clone._valueTypedLists = _valueTypedLists.ToList();
            return clone;
        }
    }
