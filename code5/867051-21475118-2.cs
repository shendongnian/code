    public class Student
    {
        public Student()
        {
            this.mark = new Mark();
        }
    
        public int id { get; set; }
        public Mark mark { get; set; }
    }
    public class Mark
    {
        public int value { get; set; }
    }
