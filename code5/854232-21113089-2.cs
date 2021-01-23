    public class Item
    {
        public override int GetHashCode()
        {
            return Name == null ? 0 : Name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if(object.ReferenceEquals(this, obj)) return true;
            Item i2 = obj as Item;
            if(i2 == null) return false;
            return StringComparer.CurrentCulture.Equals(Name, i2.Name);
        }
        // rest of class  ...
    }
