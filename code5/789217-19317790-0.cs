    public void Update(CustomerEditViewModel model)
    {
	    var customerDb = _customerRep.GetAll().NotLazy(f => f.ContactPersons).SingleOrDefault(f => f.Id == model.Id);
	    foreach(var contactPerson in customerDb.ContactPersons.ToList())
	    {
		    _customerRep.Delete(contactPerson);
	    }
    }
