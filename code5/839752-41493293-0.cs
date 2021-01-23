    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace System.ComponentModel.DataAnnotations.Schema
    {          
      public class ScalarStringCollection : ScalarCollection<string> { }
      /// <summary>
      /// If you add read/write properties, don't forget to attribute with <see cref="NotMapped"/>, unless you want it in the database.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      [ComplexType]
      public abstract class ScalarCollection<T> : ICollection<T>
      {
        public const string DefaultSeparator = "\n";
        public string Separator { get; set; }
    
        public ScalarCollection(string separator = DefaultSeparator)
        {
          Separator = separator;
          Items = new List<T>();
        }
    
        /// <summary>
        /// Gets or sets a linebreak-separated collection of the column content.
        /// </summary>
        [Required]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not to be used directly by user, use Duration property instead.")]
        internal string Data
        {
          get
          {
            return string.Join(Separator, Items.Select(item => OnSerialize(item)));
          }
          set
          {
            Items.Clear();
            if (string.IsNullOrWhiteSpace(value))
              return;
    
            Items = value.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries).Select(item => OnDeserialize(item)).ToList();
          }
        }
    
        protected virtual T OnDeserialize(string item)
        {
          try
          {
            return (T)Convert.ChangeType(item, typeof(T));
          }
          catch
          {
            throw new FormatException(string.Format("'{0}' is an unrecognized {1} format, please override the OnDecode method.", item, typeof(T)));
          }
        }
    
        protected virtual string OnSerialize(T item)
        {
          return Convert.ToString(item);
        }
    
        protected ICollection<T> Items { get; private set; }
    
        public virtual void Add(T item)
        {
          if(item is ValueType)
            Items.Add(item);
    
          var str = item as string;
          if (str != null || (str.Any(ch => !char.IsWhiteSpace(ch)) && !str.Contains(Separator)))
            Items.Add(item);
        }
    
        public void Clear()
        {
          Items.Clear();
        }
    
        public bool Contains(T item)
        {
          return Items.Contains(item);
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
          Items.CopyTo(array, arrayIndex);
        }
    
        public int Count
        {
          get { return Items.Count; }
        }
    
        public bool IsReadOnly
        {
          get { return false; }
        }
    
        public bool Remove(T item)
        {
          return Items.Remove(item);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
          return Items.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
          return ((IEnumerable)Items).GetEnumerator();
        }
      }
    }
