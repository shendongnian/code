    public class MyCollection : KeyedCollection<string, A>
    {
        protected override GetKeyForIte(A a)
        {
            return a.Key;
        }
    }
