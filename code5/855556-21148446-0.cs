	public ActionResult UpdateDetails()
	{
		var person = repository.GetLoggedInPerson();
		LoggedInPersonViewModel vm = new LoggedInPersonViewModel();
		vm.PersonId = person.PersonId;
		//Rest of properties
		...
		
		//return view model
		return View(vm);
	}
