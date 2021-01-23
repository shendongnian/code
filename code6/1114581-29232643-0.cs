    public class Lin : IEquatable<Lin>
    {
        public string DbName {get;set;}
        public string ObjectName {get;set;}
        public override bool Equals(object obj) {
            return Equals(obj as Lin);
        }
        public bool Equals(Lin other) {
            return other != null
               && this.DbName == other.DbName
               && this.ObjectName == other.ObjectName;
        }
        public override int GetHashCode() {
            int x = DbName == null ? 0 : DbName.GetHashCode();
            int y = ObjectName == null ? 0 : ObjectName.GetHashCode();
            return (-1423 * x) ^ y;
        }
    }
