    class Employee
    {
        protected bool Equals(Employee other)
        {
            return string.Equals(Code, other.Code);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee) obj);
        }
        public override int GetHashCode()
        {
            return (Code != null ? Code.GetHashCode() : 0);
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string WorkingStatus { get; set; }
    }
