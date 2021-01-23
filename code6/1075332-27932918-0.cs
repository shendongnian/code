    public class MyCollection<T> : IEnumerable<T>, ICollection<T>
    {
        // ... Implemented methods
    }
    // ...
    void Foo(IEnumerable<int> elements)
    {
        int count;
        if (elements is ICollection<int>) {
            count = ((ICollection<int>)elements).Count;
        }
        else {
            // Use Linq to traverse the whole enumerable; less efficient, but correct
            count = elements.Count();
        }
    }
    // ...
    
    MyCollection<int> myStuff;
    Foo(myStuff);
