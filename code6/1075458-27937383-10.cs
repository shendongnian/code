    class xxx : IComparable<xxx>
    {
        public string FileName { get; set; }
        public int CompareTo(xxx other)
        {
            // Short circuit if any object is null, if the
            // Filenames equal each other, or they're empty
            if (other == null) return 1;
            if (FileName == null) return (other.FileName == null) ? 0 : -1;
            if (other.FileName == null) return 1;
            if (FileName.Equals(other.FileName)) return 0;
            if (string.IsNullOrWhiteSpace(FileName)) 
                return (string.IsNullOrWhiteSpace(other.FileName)) ? 0 : -1; 
            if (string.IsNullOrWhiteSpace(other.FileName)) return 1;
            // Next, try to get the numeric portion of the string to compare
            int thisIndex;
            int otherIndex;
            var thisSuccess = int.TryParse(FileName.Split('_')[0], out thisIndex);
            var otherSuccess = int.TryParse(other.FileName.Split('_')[0], out otherIndex);
            // If we couldn't get the numeric portion of the string, use int.MaxValue
            if (!thisSuccess)
            {
                // If neither has a numeric portion, just use default string comparison
                if (!otherSuccess) return FileName.CompareTo(other.FileName);
                thisIndex = int.MaxValue;
            }
            if (!otherSuccess) otherIndex = int.MaxValue;
            // Return the comparison of the numeric portion of the two filenames
            return thisIndex.CompareTo(otherIndex);
        }
        public override string ToString()
        {
            return FileName;
        }
    }
