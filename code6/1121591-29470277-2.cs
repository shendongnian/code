    public class ModInfo : IEquatable<ModInfo>
    {
        public int ID { get; set; }
        public string MD5 { get; set; }
        public bool Equals(ModInfo other)
        {
            if (other == null) return false;
            return (this.MD5.Equals(other.MD5));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + MD5.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            ModInfo other = obj as ModInfo;
            if (other != null)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }
    }
