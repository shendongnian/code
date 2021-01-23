    // your person model where you hold person info
    public class Person
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int Age {get; set;}
        public string Sex {get; set;}
    }
    // You will hold not strings but real objects in combo
    private void LoadCombo()
    {
        var john = new Pesron(){Id = 0, Name = "John", Age = 20, sex = "Male"};
        var maria = new Pesron(){Id = 1, Name = "Maria", Age = 19, sex = "Female"};
        var couple = new []{john, maria};
        combobox.DataSourse = couple;
        combobox.DisplayMember = "Name";
        combobox.ValueMember = "Id";
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Then you can have entire person information at your disposal
        var p = (Person)combobox.SelectedItem;
                
        textbox.text = string.Format("Name {0}, Age {1}", p.Name, p.Age);
    }
