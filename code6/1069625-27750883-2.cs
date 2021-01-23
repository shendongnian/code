    class PermissionsKey
    {
        public string sectionName;
        public string KeyIndex;
    
        public override Equals(object obj)
        {
            var key = obj as PermissionsKey;
            if (key == null)
                return false;
            return sectionName.Equals(key.sectionName) &&
                   KeyIndex.Equals(key.KeyIndex);
        }
        //Credit to Jon Skeet from http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        //  for inspiration for this method
        public override GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int) 2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 ^ sectionName.GetHashCode();
                hash = hash * 16777619 ^ KeyIndex.GetHashCode();
                return hash;
            }
        }
    }
