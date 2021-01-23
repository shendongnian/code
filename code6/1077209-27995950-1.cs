    public class pKeys
    {
        public pKeys()
        { }
        public pKeys(long sID, long pID)
        {
            this.seID = sID;
            this.pgID = pID;
        }
        public readonly long seID;
        public readonly long pgID;
        public override int GetHashCode()
        {
            return seID.GetHashCode() * 37 + pgID.GetHashCode();
        }
        public override bool Equals(object other)
        {
            pKeys otherKeys = other as pKeys;
            return otherKeys != null &&
                this.seID == otherKeys.seID &&
                this.pgID == otherKeys.pgID;
        }
    }
