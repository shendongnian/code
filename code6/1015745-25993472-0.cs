    public class VersionSettings
    {
        public String Culture { get; set; }
        public String Domain { get; set; }
        public String Name { get; set; }
        public override bool Equals(object obj)
        {
            VersionSettings other = obj as VersionSettings;
            if(other == null) return false;
            return Culture == null && other.Culture == null || ;
        }
        public override int GetHashCode()
        {
            return Culture == null ? 0 : Culture.GetHashCode();
        }
    }
