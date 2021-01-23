    public class EmployeeObject
    {
        public Int32 Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public override int GetHashCode()
        {
            int code = 19;
            code = code * 23 + Id.GetHashCode();
            code = code * 23 + Title.GetHashCode();
            code = code * 23 + Desc.GetHashCode();
            return code;
        }
        public override bool Equals(object obj)
        {
            EmployeeObject other = obj as EmployeeObject;
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && 
                   Title == other.Title && Desc == other.Desc;                 
        }
    }
