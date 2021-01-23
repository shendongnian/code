    public class SomeModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int ContactID { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, Surname);
            }
        }
    }
