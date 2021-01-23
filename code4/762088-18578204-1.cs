    public class Person
    {
        public int personId { get; set; }
        public string personName { get; set; }
        public string personEmail { get; set; }
        public string personPhone { get; set; }
        public DateTime personDOB { get; set; }
        public Boolean isPersonActive { get; set; }
        public string Summary
        {
            get { return string.Format("{0} - {1} : {2} -- {3}", personName, personEmail, personPhone, personDOB); }
        }
    }
