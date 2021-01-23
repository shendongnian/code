    Mapper.CreateMap<Client, PersonResult>()
    	.ProjectUsing(c => new PersonResult()
    	{
    		Name = c.Person.FirstName + " " + c.Person.LastName
    		...
    	});
