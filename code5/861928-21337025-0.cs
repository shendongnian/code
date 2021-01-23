    public static List<PersonModel> GetPeople()
    {
        List<PersonModel> people = new List<PersonModel>();
        
        DataSet data = SomeMethodToGetTheDataSet();
        foreach(DataRow in data.Tables[0].Rows)
        {
            PersonModel person = getPersonFromDataRow();
            people.Add(person);
        }
        return people;
    }
    private static PersonModel getPersonFromDataRow(DataRow row)
    {
        PersonModel person = new PersonModel();
        person.ID = row.Field<int>("Identificator");
        person.FirstName = row.Field<string>("First_Name");
        person.LastName = row.Field<string>("Last_Name");
        return person;
    }
