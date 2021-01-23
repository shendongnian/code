    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        SavePerson(TextBoxFirstName.Text, TextBoxLastName.Text);
    }
    private SavePerson(string firstName, string lastName)
    {
       using (PeopleEntities ctx = new PeopleEntities())
       {
          var person = GetPerson(ctx);
          person.FirstName = firstName;
          person.LastName = lastName;
          ctx.SaveChanges();
       }
    }
