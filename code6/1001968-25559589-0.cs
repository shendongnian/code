    class MasterList : IEquatable<MasterList>
    {
        public int ID = int.MinValue;
        public DateTime LastUpdated = DateTime.MinValue;
        public MasterList(String sId, String sLastUpdated)
        {
            if (!string.IsNullOrEmpty(sId) && 
                !string.IsNullOrEmpty(sLastUpdated))
            {
                ID = Convert.ToInt32(sID);
                LastUpdated = Convert.ToDateTime(sLastUpdated);      
            }
        }
        public bool Equals(MasterList other)
        {
            return (this.ID == other.ID &&
                    this.LastUpdated == other.LastUpdated);
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode() * this.LastUpdated.GetHashCode();
        }
    }
