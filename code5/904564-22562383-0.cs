    public class ApplicationsDetailsModelEqualityComparer : IEqualityComparer<ApplicationsDetailsModel>
    {
        public bool Equals(ApplicationsDetailsModel x, ApplicationsDetailsModel y)
        {
            return x.AppNum == y.AppNum && x.AppName == y.AppName;
        }
        public int GetHashCode(ApplicationsDetailsModel obj)
        {
            int hashCode = (obj.AppName != null ? obj.AppName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ obj.AppNum.GetHashCode();
            return hashCode;
        }
    }
