    protected void Page_Load(object sender, EventArgs e)
    {
        Person MyPerson = new Person();
        MyPerson.Name = txtName.Text;
        MyPerson.Surname = txtSurname.Text;
        MyPerson.DateOfBirth = txtBirth.Text;
        MyPerson.Gender = listGender.Text;
        MyPerson.Symptoms = checked(listSymptoms.Text);
        Session["CurrentPerson"] = MyPerson;
    }
