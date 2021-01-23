    public class ApplicationsDetailsModelComparer : IEqualityComparer<ApplicationsDetailsModel> {
        public bool Equals(ApplicationsDetailsModel first, ApplicationsDetailsModel second) {
            return first.AppNum == second.AppNum;
        }
        public int GetHashCode(ApplicationsDetailsModel applicationsDetailsModel) {
            return applicationsDetailsModel.AppNum.GetHashCode();
        }
    }
