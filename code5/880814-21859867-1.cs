    public class MyCollection : KeyedCollection<string, A>
    {
        protected override GetKeyForItem(A a)
        {
            return a.Key;
        }
    }
