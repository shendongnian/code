    public class StudentInfo
    {
        public StudentInfo(int ID, string Name, string Email, string PhoneNo)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNo = PhoneNo;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
