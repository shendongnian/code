    public class DistrictSupervisorViewModel  : IEquatable<DistrictSupervisorViewModel>
    {
        public bool Equals(DistrictSupervisorViewModel other)
        {
            // Do your own comparing here
            return this.DistrictId == other.DistrictId;
        }
    }
