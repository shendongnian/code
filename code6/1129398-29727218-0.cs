    // A simple Person class, Name + Surname
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
    // cb is your ComboBox
    // Three persons in the ComboBox
    cb.Items.Add(new Person { Name = "Bill", Surname = "Gates" });
    cb.Items.Add(new Person { Name = "Larry", Surname = "Ellison" });
    cb.Items.Add(new Person { Name = "Peter", Surname = "Norton" });
    // and then somewhere the user selects an item in the combobox
    // and then we can
    Person selectedPerson = (Person)cb.SelectedItem;
    string selectedPersonDescription = cb.SelectedText;
