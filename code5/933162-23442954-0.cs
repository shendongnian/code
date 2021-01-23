    public int GetHashCode(Column obj)
    {
        unchecked
        {
            var hashCode = obj.StartElevation.GetHashCode();
            hashCode = (hashCode * 397) ^ obj.EndElevation.GetHashCode();
            foreach (var item in obj.ListOfSections)
            {
                hashCode = (hashCode * 397) ^ item.GetHashCode();
            }
            return hashCode;
        }
    }
