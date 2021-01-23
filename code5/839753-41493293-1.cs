    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Reflection;
    
    namespace System.ComponentModel.DataAnnotations.Schema
    {
      /// <summary>
      /// If you add read/write properties, don't forget to attribute with <see cref="NotMapped"/>, unless you want it in the database.
      /// </summary>
      /// <typeparam name="T"></typeparam>
    #if NET462
      [ComplexType]
    #endif
      public abstract class ScalarCollection<T> :
    #if NET462
        Collection<T>,
    #else
        ObservableCollection<T>,
    #endif
        IEqualityComparer<T>,
        IValidatableObject
      {
        public const string DefaultSeparator = "\n";
        public const char ReplacementChar = '\u23ce';
    
        public ScalarCollection(params T[] values)
        {
          if (values != null)
            foreach (var item in Items)
              Items.Add(item);
        }
    
    #if NET462
        [NotMapped]
    #endif
        public string Separator { get; set; } = DefaultSeparator;
    
    #if NET462
        [NotMapped]
    #endif
        public bool AllowDuplicates { get; set; } = false;
    
        /// <summary>
        /// Gets or sets whether case sensitivity is considered when checking for duplicate values.
        /// </summary>
    #if NET462
        [NotMapped]
    #endif
        public bool IsCaseInsensitive { get; set; } = false;
    
        /// <summary>
        /// Gets or sets a linebreak-separated collection of the column content.
        /// </summary>
    #if NET462
        [Browsable(false)]
    #endif
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not to be used directly by user, use Items property instead.")]
        public string Data
        {
          get
          {
            var data = Items.Select(item => Serialize(item).Replace(Separator, ReplacementChar.ToString()));
            return string.Join(Separator, data.Where(s => s?.Length > 0));
          }
          set
          {
            Items.Clear();
            if (string.IsNullOrWhiteSpace(value))
              return;
    
            foreach (var item in value.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries).Select(item => Deserialize(item)))
              Items.Add(item);
          }
        }
    
        public void AddRange(params T[] items)
        {
          if (items != null)
            foreach (var item in items)
              Add(item);
        }
    
        protected virtual string Serialize(T item)
        {
          return Convert.ToString(item);
        }
    
        protected virtual T Deserialize(string item)
        {
          //TODO:
          try
          {
            return (T)Convert.ChangeType(item, typeof(T));
          }
          catch
          {
            throw new FormatException(string.Format("'{0}' is an unrecognized {1} format, please override the OnDecode method.", item, typeof(T)));
          }
        }
    
        //static readonly bool IsValueType = typeof(T).GetTypeInfo().IsValueType;
        //static readonly bool IsString = typeof(T) == typeof(string);
    
        public virtual IEnumerable<ValidationResult> OnValidate(ValidationContext validationContext, T current) =>
          new ValidationResult[] { };
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          var result = new List<ValidationResult>();
          foreach (var item in this)
          {
            var results = OnValidate(validationContext, item);
            result.AddRange(results.Where(r => r != null && r != ValidationResult.Success));
          }
    
          return
            result.Any() ?
            result.ToArray() :
            new[] { ValidationResult.Success };
        }
    
    
        protected override void SetItem(int index, T item)
        {
          if (AllowDuplicates || !Items.Contains(item, this))
            base.SetItem(index, item);
        }
    
        protected override void InsertItem(int index, T item)
        {
          if (AllowDuplicates || !Items.Contains(item, this))
            base.InsertItem(index, item);
        }
    
        IEqualityComparer<string> Comparer => IsCaseInsensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
        public virtual bool Equals(T x, T y) => Comparer.Equals(Serialize(x), Serialize(y));
        public virtual int GetHashCode(T obj) => Comparer.GetHashCode(Serialize(obj));
      }
    
      public class ScalarStringCollection : ScalarCollection<string>
      {
        public ScalarStringCollection() { }
    
        public ScalarStringCollection(params string[] values) : base(values) { }
      }
    }
