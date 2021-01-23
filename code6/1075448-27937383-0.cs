    class xxx : IComparable<xxx>
    {
        public string FileName { get; set; }
        public int CompareTo(xxx other)
        {
            if (other == null) return 1;
            if (FileName == null) return (other.FileName == null) ? 0 : -1;
            if (FileName.Equals(other.FileName, StringComparison.OrdinalIgnoreCase)) 
                return 0;
            int thisIndex;
            int otherIndex;
            var thisSuccess = int.TryParse(FileName.Split('_')[0], out thisIndex);
            var otherSuccess = int.TryParse(other.FileName.Split('_')[0], out otherIndex);
            if (!thisSuccess) return (otherSuccess) ? -1 : 0;
            if (!otherSuccess) return 1;
            return thisIndex.CompareTo(otherIndex);
        }
        public override string ToString()
        {
            return FileName;
        }
    }
