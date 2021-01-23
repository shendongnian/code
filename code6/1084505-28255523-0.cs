        public override int GetHashCode(Student obj)
        {
            unchecked
            {
                return obj.StudentName.GetHashCode() + obj.Age.GetHashCode();
            }
        }
