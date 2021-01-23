    var students = dc
        .AsEnumerable() // In case you're using a linq-to-sql framework, this will ensure the query execute in-memory
        .Distinct(new SpecialtyComparer());
    //...
    public class SpecialtyComparer : IEqualityComparer<StudentTable>
    {
        public int GetHashCode(StudentTable s)
        {
            return s.studentname.GetHashCode()
                && s.subject.GetHashCode()
                && s.grade.GetHashCode();
        }
        public bool Equals(StudentTable s1, StudenTable s2)
        {
            return s1.studentname.Equals(s2.studentname)
                && s1.subject.Equals(s2.subject)
                && s1.grade.Equals(s2.grade);
        }
    }
