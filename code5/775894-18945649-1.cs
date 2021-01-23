    class Person
    {
       public string Name { get; set; }
       public int Age { get; set; }
    }
    
    var persons = new List<Person> { 
        new Person("Adam", 10), 
        new Person("Thomas", 20) };
    comboBox.DataSource = persons;
    comboBox.DisplayMember = "Name";
    
    comboBox.SelectedItem = "Adam"; // this will not display a person named Thomas because the combobox is binded to the Person type
    comboBox.SelectedItem = persons.Where(p => p.Name == "Thomas").Single(); // this will show Adam if it is available in the comboBox
