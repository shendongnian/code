    public class EmployeeComparer : IEqualityComparer<EmployeeObject>
    {
        public bool Equals(EmployeeObject x, EmployeeObject y)
        {
            return x.Id == y.Id
                && x.Title == y.Title
                && x.Desc == y.Desc;
        }
        public int GetHashCode(EmployeeObject obj)
        {
            int code = 19;
            code = code * 23 + obj.Id.GetHashCode();
            code = code * 23 + obj.Title.GetHashCode();
            code = code * 23 + obj.Desc.GetHashCode();
            return code;
        }
    }
