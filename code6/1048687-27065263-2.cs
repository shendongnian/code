	// Implement interface, if you go for dependency injection or unit tests
	public class PartyRegistrationService 
	{	
		private RegistrationRepository registrationRepository;
		private PartyRepository partyRepository;
		private PersonRepository personRepository;
		
		// inject the repositories here, if you use DI
		public PartyRegistrationService() 
		{
			this.registrationRepository = new RegistrationRepository();
			this.personRepository = new PersonRepository();
			this.partyRepository = new PartyRepository();
		}
		
		public bool RegisterPersonToParty(int personId, int partyId) 
		{
			Person person = personRepository.GetById(personId);
			Party party = partyRepository.GetById(partyId);
			
			// invalid person or party id
			if(person==null || party==null)
				return false;
				
			if(registrationRepository.GetByPerson(person)!=null) 
			{
				// person has a registration already
				return false;
			}
			
			// person has no registration yet
			var registration = new Registration(person, party);
			registrationRepository.Save(registration);
			
			return true;
		}
	}
