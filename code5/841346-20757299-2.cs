    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public class Product : BaseEntity
    {
       public string Name { get; set; }
       public decimal Price { get; set; }
    }
    //Generic Comparer
    public class EntityComparer<T> :  IEqualityComparer<T>, IComparer<T> 
    where T : BaseEntity
    {
        public enum AscDesc : short
        {
            Asc, Desc
        }
        #region Const
        public string PropertyName { get; set; }
        public AscDesc SortType { get; set; }
        #endregion
        #region Ctor
        public EntityComparer(string _propertyname = "Id", AscDesc _sorttype = AscDesc.Asc)
        {
            this.PropertyName = _propertyname;
            this.SortType = _sorttype;
        }
        #endregion
        #region IComparer
        public int Compare(T x, T y)
        {
            if (typeof(T).GetProperty(PropertyName) == null)
                throw new ArgumentNullException(string.Format("{0} does not contain a property with the name \"{1}\"", typeof(T).Name, PropertyName));
            var xValue = (IComparable)x.GetType().GetProperty(this.PropertyName).GetValue(x, null);
            var yValue = (IComparable)y.GetType().GetProperty(this.PropertyName).GetValue(y, null);
            if (this.SortType == AscDesc.Asc)
                return xValue.CompareTo(yValue);
            return yValue.CompareTo(xValue);
        }
        #endregion
        #region IEqualityComparer
        public bool Equals(T x, T y)
        {
            if (typeof(T).GetProperty(PropertyName) == null)
                throw new InvalidOperationException(string.Format("{0} does not contain a property with the name -> \"{1}\"", typeof(T).Name, PropertyName));
            var valuex = x.GetType().GetProperty(PropertyName).GetValue(x, null);
            var valuey = y.GetType().GetProperty(PropertyName).GetValue(y, null);
            if (valuex == null) return valuey == null;
            return valuex.Equals(valuey);
        }
        public int GetHashCode(T obj)
        {
            var info = obj.GetType().GetProperty(PropertyName);
            object value = null;
            if (info != null)
            {
                value = info.GetValue(obj, null);
            }
            return value == null ? 0 : value.GetHashCode();
        }
        #endregion
    }
     //Usage
     Product product = new Product();
     Product product2 =new Product();
     EntityComparer<Product> comparer = new EntityComparer<Product>("Propert Name Id Name whatever u want", Asc Or Desc);
     comparer.Compare(product, product2);
