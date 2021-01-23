    public class PersonsSelectItems
    {
        public int SelectedId { get; set; }
        public List<Person> Persons { get; set; }
        public PersonsSelectItems() {
            Persons = new List<Person>();
        }
    }
