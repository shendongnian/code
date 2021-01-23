    // within your form class, whatever it is
    public Person CreatePerson()
    {
        Person MyPerson = new Person();
        MyPerson.Name = txtName.Text;
        MyPerson.Surname = txtSurname.Text;
        MyPerson.DateOfBirth = txtBirth.Text;
        MyPerson.Gender = listGender.Text;
        MyPerson.Symptoms = checked(listSymptoms.Text);
        return MyPerson;
    }
