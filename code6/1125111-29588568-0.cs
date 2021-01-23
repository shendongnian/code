	// create the resolver class 
	// -> extract person info from DTO and return a new Person object
	public class CustomResolver : ValueResolver<ApprenticeshipDto, Person>
	{
		protected override Person ResolveCore(ApprenticeshipDto source)
		{
			return new Person
				{
						FirstName = source.PersonFirstName,
						LastName = source.PersonLastName
				};
		}
	}
