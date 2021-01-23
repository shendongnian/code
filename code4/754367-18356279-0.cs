    class Foo:Idisposable 
    {
        public void Dispose(bool b)
        {
             MyCollection.CollectionChanged -= MyCollection_CollectionChanged;
        }
    }
