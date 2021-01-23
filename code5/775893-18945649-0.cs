    class Person
    {
       public string Name { get; set; }
       public int Age { get; set; }
    }
    
    var persons = new List<Person>();
    comboBox.DataSource = persons;
    
    comboBox.SelectedItem = "Adam"; // this will not display a person named Adam because the combobox is binded to the Person type
    comboBox.SelectedText = "Adam"; // this will show Adam if it is available in the comboBox
