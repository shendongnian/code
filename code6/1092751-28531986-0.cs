    // This should be the handler for the save button.
    // A button, which when will be clicked a new Person should be inserted in    
    // the database.
    private void Save_Click(object sender, EventArgs e)
    {
        Person newPerson = new Person();
        newPerson.name = textBox1.Text;
        newPerson.age = textBox2.Text;
        var toSql= new ToSQL();
        toSql.Save(newPerson);
    }
