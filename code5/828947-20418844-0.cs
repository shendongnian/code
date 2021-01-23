    class PackagesEqualityComparer : IEqualityComparer<PackagesType>
    {
        public bool Equals(PackagesType x, PackagesType y)
        {
            return x.InformationFields.Model == y.InformationFields.Model;
        }
        public int GetHashCode(PackagesType obj)
        {
            return obj.InformationFields.Model.GetHashCode();
        }
    }
