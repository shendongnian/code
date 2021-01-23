    public class Person {
        const string PersonalGroup = "Personal";
        [Display(Name = "First Name", GroupName = PersonalGroup)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name", GroupName = PersonalGroup)]
        public string LastName { get; set; }
        [Display(Name = "Birth date", GroupName = PersonalGroup)]
        public DateTime BirthDate { get; set; }
        [Display(GroupName = PersonalGroup)]
        public int Age { get; set; }
        [Display(GroupName = "Contact"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
