    sealed class Foo : IEnumerable<Foo>
    {
        IEnumerator<Foo> GetEnumerator()
        {
            throw new NotImplmentedException();
        }
    
        object IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Bar
    {
    }
