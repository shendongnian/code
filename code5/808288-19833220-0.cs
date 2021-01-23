     public class PersonRow : DataGridViewRow
        {
            public DataGridViewTextBoxCell Name;
            public DataGridViewComboBoxCell Phones;
            public DataGridViewComboBoxCell Cars;
            public PersonRow(Person person)
            {
                Name.Value = person.Name;
                DataGridViewComboBoxCell phones = new DataGridViewComboBoxCell();
                phones.Items.AddRange((DataGridViewComboBoxCell.ObjectCollection)person.Phones); //add the items from Person.Phones to PersonRow.Phones combobox cell
                Phones = phones;
                DataGridViewComboBoxCell cars = new DataGridViewComboBoxCell();
                cars.Items.AddRange((DataGridViewComboBoxCell.ObjectCollection)person.Cars); //add Person.Cars to PersonRow.Cars combobox cell 
                Cars = cars;
                Cells.AddRange(new DataGridViewCell[] { Name, Phones, Cars }); //add cells to the row
                
            }
        }
    public class Person
        {
            public string Name { get; set; }
            public IList<Phones>  Phones { get; set; } //be sure to use the IList interface
            public IList<Cars> Cars { get; set; } //be sure to implement the IList interface
            public Person( string name, List<Phones> phones, List<Cars> cars)
            {
                Name = name;
                Phones = phones;
                Cars = cars;
            }
        }
    public class Phones
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public Phones(string name, string model)
            {
                Name = name;
                Model = model;
            }
        }
        public class Cars
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public Cars(string name, string model)
            {
                Name = name;
                Model = model;
            }
        }
