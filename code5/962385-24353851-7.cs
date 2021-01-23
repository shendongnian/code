	var persons = new List<Person>
	{
		new Person { Age = 20 },
		new Person { Age = 30 },
		new Person { Age = 20 },
		new Person { Age = 40 },
		new Person { Age = 50 },
		new Person { Age = 50 },
		new Person { Age = 20 }
	};
	
	var result =    from person in persons
					group person by person.Age into g
					select g.ToList();
	var listOfListOfPersons = result.ToList();
