    class Student
    {
        public string PassPort { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public string this[int index]
        {
            get { throw new NotImplementedException(); }
            set
            {
                switch (index)
                {
                    case 0:
                        PassPort = value;
                        break;
                    case 1:
                        // etc.
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
