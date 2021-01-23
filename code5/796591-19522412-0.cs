    class Program
    {
      static void Main(string[] args)
      {
         MyClassList l = new MyClassList() { new MyClass() {Type="Bob", Id=1}, new MyClass() {Type="Jones", Id=2}};
         MyClassList l2 = new MyClassList() { new MyClass() { Type = "Jones", Id = 2 }, new MyClass() { Type = "Bob", Id = 1 } };
         MyClassList l3 = new MyClassList() { new MyClass() { Type = "Jones", Id = 2 }};
         Console.WriteLine("{0} {1} {2}", l.GetHashCode(), l2.GetHashCode(), l3.GetHashCode());
         l3.Add(new MyClass() { Type = "Bob", Id = 1 });
         Console.WriteLine("{0}", l3.GetHashCode());
      }
    }
    public class MyClass
    {
      public string Type { get; set; }
      public int Id { get; set; }
      public override int GetHashCode()
      {
         return (Type.GetHashCode() % 0x8000) | (int)((uint)Id.GetHashCode() & 0xFFFF0000);
      }
    }
    public class MyClassList : IList<MyClass>
    {
      List<MyClass> internalList;
      int hashCode = 0;
      public MyClassList()
      {
         internalList = new List<MyClass>();
      }
      private void IncludeInHash(MyClass item)
      {
         hashCode ^= item.GetHashCode();
      }
      private void ExcludeFromHash(MyClass item)
      {
         IncludeInHash(item);
      }
      public override int GetHashCode()
      {
         return hashCode;
      }
      public int IndexOf(MyClass item)
      {
         return internalList.IndexOf(item);
      }
      public void Insert(int index, MyClass item)
      {
         internalList.Insert(index, item);
         // Make sure Insert is successful (doesn't throw an exception) before affecting the hash
         IncludeInHash(item);
      }
      public void RemoveAt(int index)
      {
         MyClass reduce = internalList[index];
         internalList.RemoveAt(index);
         // Make sure RemoveAt is successful before affecting the hash
         ExcludeFromHash(reduce);
      }
      public MyClass this[int index]
      {
         get
         {
            return internalList[index];
         }
         set
         {
            MyClass reduce = internalList[index];
            internalList[index] = value;
            // Make sure these happen atomically; don't allow exceptions to prevent these from being accurate.
            ExcludeFromHash(reduce);
            IncludeInHash(value);
         }
      }
      public void Add(MyClass item)
      {
         internalList.Add(item);
         IncludeInHash(item);
      }
      public void Clear()
      {
         internalList.Clear();
         hashCode = 0;
      }
      public bool Contains(MyClass item)
      {
         return internalList.Contains(item);
      }
      public void CopyTo(MyClass[] array, int arrayIndex)
      {
         internalList.CopyTo(array, arrayIndex);
      }
      public int Count
      {
         get { return internalList.Count; }
      }
      public bool IsReadOnly
      {
         get { return false; }
      }
      public bool Remove(MyClass item)
      {
         if (internalList.Remove(item))
         {
            ExcludeFromHash(item);
            return true;
         }
         else
            return false;
      }
      public IEnumerator<MyClass> GetEnumerator()
      {
         return internalList.AsReadOnly().GetEnumerator();
      }
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
    }
