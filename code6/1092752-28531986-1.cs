    // This should be the handler for the save button.
    // A button, which when will be clicked a new Person should be inserted in    
    // the database.
    private void Save_Click(object sender, EventArgs e)
    {
        // Here we create a new Person object.
        Person newPerson = new Person();
        newPerson.name = textBox1.Text;
        newPerson.age = textBox2.Text;
        // Here we create an instance of the ToSQL class.
        // This is the class, whose definition is in the toSQL.cs file 
        ToSQL toSql= new ToSQL();
        // Here we call a method called SavePerson, which inserts a new
        // Person in the database.
        toSql.SavePerson(newPerson);
    }
