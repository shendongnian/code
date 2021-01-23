    //
    // GET: /Desktop/GetPersons
    public PartialViewResult GetPersons()
    {
        var persons = this.desktopService.GetPersons()
            .OrderBy(x => Guid.NewGuid()); // randomize to make it look like a refresh
        return PartialView("_PeoplePartial", persons);
    }
    //
    // GET: /Desktop/GetPlaces
    public PartialViewResult GetPlaces()
    {
        var places = this.desktopService.GetPlaces()
            .OrderBy(x => Guid.NewGuid()); // randomize to make it look like a refresh
        return PartialView("_PlacesPartial", places);
    }
