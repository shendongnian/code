    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        // Do the sort order of the pet names while you set the value
        IEnumerable<string> petNames = new HashSet<string>();
        public IEnumerable<string> PetNames
        {
            get { return petNames.OrderBy(p => p); }
            set { petNames = value; } // Or sorting could be done in set as well
        }
    }
