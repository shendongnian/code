    public class Student
    {
        private string mFirstName;
        public string FirstName
        {
            get
            {
                return mFirstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == true)
                    throw new ArgumentOutOfRangeException("Please enter a first name");
                mFirstName = value;
            }
        }
    }
