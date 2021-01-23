    public class City : DomainEntity, IAggregateRoot
    {
        public City(string name, decimal latitude, decimal longitude)
        {
            Name = name;
            SetLocation(latitude, longitude);
        }
        // Just make it internal
        internal City(string name, decimal latitude, decimal longitude, int id)
            : base(id)
        {
            Name = name;
            Coordinate = coordinate;
            SetLocation(latitude, longitude);
        }
    }
