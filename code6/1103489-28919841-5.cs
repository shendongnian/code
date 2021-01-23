    public class OrderDetailsListItem : INotifyPropertyChanged, IEquatable<OrderDetailsListItem>
    {
        //(Snip everything from the first example)
        public bool Equals(OrderDetailsListItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            return string.Equals(_name, other._name);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as OrderDetailsListItem);
        }
        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }
    }
