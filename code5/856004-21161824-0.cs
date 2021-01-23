    public class DoubleList : IList<double>
    {
      private readonly List<object> _source; // Change to IList<object> if that's a possibility
      public DoubleList(List<object> source)
      {
        _source = _source;
      }
      // Hide half-supported implementation from main interface
      double IList<double>.this[int index]
      {
        get { return Convert.ToDouble(_source[index]); }
        set { throw new NotSupportedException("Read-only collection"); }
      }
      public double this[int index]
      {
        get { return Convert.ToDouble(_source[index]); }
      }
      public int Count
      {
        get { return _source.Count; }
      }
      bool ICollection<double>.IsReadOnly
      {
        get { return true; }
      }
      /* Lots of boring and obvious implementations skipped */
      public struct Enumerator : IEnumerator<double>
      {
        // note, normally we'd just use yield return in the
        // GetEnumerator(), and we certainly wouldn't use
        // a struct here (there are issues), but this
        // optimisation is in the spirit of "most efficient"
        private List<object>.Enumerator _en; //Mutable struct! Don't make field readonly!
        public double Current
        {
          get { return Convert.ToDouble(_en.Current); }
        }
        object IEnumerator.Current
        {
          get { return Current; }
        }
        public void Dispose()
        {
          _en.Dispose();
        }
        public bool MoveNext()
        {
          return _en.MoveNext();
        }
        public void Reset()
        {
          _en.Reset();
        }
      }
      public Enumerator GetEnumerator()
      {
        return new Enumerator(_source.GetEnumerator());
      }
      IEnumerator<double> IEnumerable<double>.GetEnumerator()
      {
        return GetEnumerator();
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
    var doubleList = new DoubleList(listOfObjects);
