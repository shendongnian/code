	var persons = new List<Person> 
	{
		new Person { ID = 1, Code = "Person1" },
		new Person { ID = 2, Code = "Person2" },
		new Person { ID = 3, Code = "Person3" }
	};
	
	var stringProperties = new List<StringProperty>
	{
		new StringProperty { ID = 1, PersonID = 1, Name = "FirstName", Value = "John" },
		new StringProperty { ID = 2, PersonID = 1, Name = "LastName", Value = "Smith" },
		new StringProperty { ID = 3, PersonID = 2, Name = "FirstName", Value = "William" },
		new StringProperty { ID = 4, PersonID = 2, Name = "LastName", Value = "Brown" },
		new StringProperty { ID = 5, PersonID = 3, Name = "FirstName", Value = "James" },
		new StringProperty { ID = 6, PersonID = 3, Name = "LastName", Value = "Miller" }
	};
	
	var numericProperties = new List<NumericProperty>
	{
		new NumericProperty { ID = 1, PersonID = 1, Name = "Age", Value = 25 },
		new NumericProperty { ID = 2, PersonID = 1, Name = "Weight", Value = 50 },
		new NumericProperty { ID = 3, PersonID = 2, Name = "Age", Value = 30 },
		new NumericProperty { ID = 4, PersonID = 2, Name = "Weight", Value = 80 },
		new NumericProperty { ID = 5, PersonID = 3, Name = "Age", Value = 32 },
		new NumericProperty { ID = 6, PersonID = 3, Name = "Weight", Value = 73 }
	};
