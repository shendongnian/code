    class PermissionsKey
    {
        private string sectionName;
        private string keyIndex;
        public string SectionName { get { return sectionName; } }
        public string KeyIndex { get { return keyIndex; } }
        public PermissionsKey(string sectionName, string keyIndex)
        {
            this.sectionName = sectionName;
            this.keyIndex = keyIndex;
        }
        public override Equals(object obj)
        {
            var key = obj as PermissionsKey;
            if (key == null)
                return false;
            return sectionName.Equals(key.sectionName) &&
                   keyIndex.Equals(key.keyIndex);
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
                hash = hash * 16777619 ^ keyIndex.GetHashCode();
                return hash;
            }
        }
    }
