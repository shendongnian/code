    public IList<Amenities> Decode(long mask)
    {
            var amenities = (Amenities)mask;
            var list = new List<Amenities>();
            foreach (Amenities amenity in Enum.GetValues(typeof(Amenities))
            {
                if (amenities.HasFlag(amenity))
                    list.Add(amenity);
            }
            return list;
    }
