    public class Person
    {
        public int ID;
        public string Name;
        public List<PhoneNumbers> PhoneNumbers;
    }
    
    public class PhoneNumbers
    {
        public int PersonID;
        public string PhoneNumber;
    }
    
	public List<Person> GetPersons()
	{
		const string query = @"select
								 p.PersonID,
								 Name,
								 PhoneNumber
							   from Persons p
							   left join PhoneNumbers n on p.PersonID = n.PersonID;";
		DataTable dataTable = Select(query);
		return (from row in dataTable.Rows.Cast<DataRow>()
			group row by row["PersonID"] into rows
			select new Person
			{
				ID = (int) rows.Key,
				Name = rows.First()["Name"] as string,
				PhoneNumbers = (from r in rows
					select new PhoneNumbers
					{
						PersonID = (int) rows.Key,
						PhoneNumber = rows.First()["PhoneNumber"] as string
					}).ToList()
			}).ToList();
	}
