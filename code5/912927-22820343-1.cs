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
    IEnumerable<Foo> selecteditems = iselect.Snapshot();
    foreach (Bar c in selecteditems) //Compile time error.
    {
        ...
