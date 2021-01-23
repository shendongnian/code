    public class TableInfo
    {
        public int item_id { get; set;}
        public string item_name { get; set;}
        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            var rhs = obj as TableInfo;
            return item_id == rhs.item_id && item_name == rhs.item_name;
        }
        public override int GetHashCode()
        {
            return item_id.GetHashCode() ^ item_name.GetHashCode();
        }
        // Additionally you can overload == and != operators:
        public static bool operator ==(TableInfo x, TableInfo y)
        {
            return object.Equals(x, y);
        }
        public static bool operator !=(TableInfo x, TableInfo y)
        {
            return !object.Equals(x, y);
        }
    }
