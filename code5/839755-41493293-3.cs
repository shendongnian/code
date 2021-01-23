    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    namespace System.Collections.Specialized
    {
    #if NET462
      [ComplexType]
    #endif
      public abstract class ScalarCollectionBase<T> :
    #if NET462
        Collection<T>,
    #else
        ObservableCollection<T>
    #endif
      {
        public virtual string Separator { get; } = "\n";
        public virtual string ReplacementChar { get; } = " ";
        public ScalarCollectionBase(params T[] values)
        {
          if (values != null)
            foreach (var item in Items)
              Items.Add(item);
        }
    #if NET462
        [Browsable(false)]
    #endif
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not to be used directly by user, use Items property instead.")]
        public string Data
        {
          get
          {
            var data = Items.Select(item => Serialize(item)
              .Replace(Separator, ReplacementChar.ToString()));
            return string.Join(Separator, data.Where(s => s?.Length > 0));
          }
          set
          {
            Items.Clear();
            if (string.IsNullOrWhiteSpace(value))
              return;
            foreach (var item in value
                .Split(new[] { Separator }, 
                  StringSplitOptions.RemoveEmptyEntries).Select(item => Deserialize(item)))
              Items.Add(item);
          }
        }
        public void AddRange(params T[] items)
        {
          if (items != null)
            foreach (var item in items)
              Add(item);
        }
        protected abstract string Serialize(T item);
        protected abstract T Deserialize(string item);
      }
      public class ScalarStringCollection : ScalarCollectionBase<string>
      {
        protected override string Deserialize(string item) => item;
        protected override string Serialize(string item) => item;
      }
      public class ScalarCollection<T> : ScalarCollectionBase<T>
        where T : IConvertible
      {
        protected override T Deserialize(string item) =>
          (T)Convert.ChangeType(item, typeof(T));
        protected override string Serialize(T item) => Convert.ToString(item);
      }
    }
