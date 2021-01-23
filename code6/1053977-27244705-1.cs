    Program {
        private const string PathSource = @"C:\schoolfiles\StudentGrades.txt";
        private struct StudentStruct
        {
            public string StudentID;
            public string StudentName;
            private List<string> _gradeList;
            public List<string> GradeList
            {
                // if _gradeList is null create a new instance
                get { return _gradeList ?? (_gradeList = new List<string>()); }
                private set { _gradeList = value; }
            }
        }
        private static void Main( string[] args )
        {
            var studentFile = File.ReadAllLines( PathSource );
            // If you haven't learned about delegates or extensions methods...
            // You can just change it to a foreach statement
            var myList = studentFile.Select( GetStudent ).ToList();
            // make sure we have everything
            foreach (var studentStruct in myList)
            {
                Console.WriteLine( "{0}  {1}", studentStruct.studentName, studentStruct.studentID );
                foreach (var grade in studentStruct.GradeList) { Console.Write( grade + " " ); }
                Console.WriteLine();
            }
        }
        private static StudentStruct GetStudent( string line )
        {
            var student = new StudentStruct();
            var studentDelimited = line.Split( ',' );
            student.studentID = studentDelimited[ 0 ];
            student.studentName = studentDelimited[ 1 ];
            for ( int i = 2; i < studentDelimited.Length; i++ ) { student.GradeList.Add( studentDelimited[ i ] ); }
            return student;
        }
    }
