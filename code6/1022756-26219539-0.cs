    public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RegionName != null ? RegionName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CountryCode != null ? CountryCode.GetHashCode() : 0);
                return hashCode;
            }
        }
