    class People
    {
        public String first_name;
        public String last_name;
        public People(string fname, string lname)
        {
            this.first_name = fname;
            this.last_name = lname;
        }
    }
    class Student : People
    {
        public int studentID;
        public Student(string fname, string lname, int studid): base(fname,lname)
        {
            this.studentID = studid;
        }
    }
