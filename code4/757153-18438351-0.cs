        public class Student:Person
        {
            private Approve m_aprove
            public Approve App { get {return m_aprove;} set {m_approve = value;}}
            public DateTime DateOfBirth { get; set; }
            public DateTime EnrollmentDate { get; set; }
            public string Remarks { get; set; }
        }
