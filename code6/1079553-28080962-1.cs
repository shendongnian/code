    public class Person
    {
        private string Fname;
        private string Lname;
        private int Id;
        private override string ToString()
        {
            return string.Format("{0}, {1} {2}", Lname, Fname, Id);
        }
        ...
        ...
    }
