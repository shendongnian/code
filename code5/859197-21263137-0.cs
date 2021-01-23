    public class SubscribeList<T> : IList<T> {
      private List<T> list;
      public EventHandler OnListContentsChange;
      public SubscribeList() {
        list = new List<T>();
      }
      public int IndexOf(T item) {
        return list.IndexOf(item);
      }
      public void Insert(int index, T item) {
        list.Insert(index, item);
        OnListContentsChange(this, EventArgs.Empty);
      }
      public void RemoveAt(int index) {
        list.RemoveAt(index);
        OnListContentsChange(this, EventArgs.Empty);
      }
      public T this[int index] {
        get {
          throw new NotImplementedException(); // do this if you want,
        }
        set {
          throw new NotImplementedException(); // but it is more complicated
        }
      }
      public void Add(T item) {
        list.Add(item);
        OnListContentsChange(this, EventArgs.Empty);
      }
      public void Clear() {
        list.Clear();
        OnListContentsChange(this, EventArgs.Empty);
      }
      public bool Contains(T item) {
        return list.Contains(item);
      }
      public void CopyTo(T[] array, int arrayIndex) {
        list.CopyTo(array, arrayIndex);
        OnListContentsChange(this, EventArgs.Empty);
      }
      public int Count {
        get { return list.Count; }
      }
      public bool IsReadOnly {
        get { return false; }
      }
      public bool Remove(T item) {
        var ok = list.Remove(item);
        if (ok) {
          OnListContentsChange(this, EventArgs.Empty);
        }
        return ok;
      }
      public IEnumerator<T> GetEnumerator() {
        foreach (var item in list) yield return item;
      }
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
        return list.GetEnumerator();
      }
    }
