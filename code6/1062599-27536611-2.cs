    [HttpPost]
    [ResponseType(typeof(PersonDto))]
    public async Task<IHttpActionResult> AddAsync([FromBody] personDto dto)
    {
        // some code to map my dto to the entity using automapper, and save the new entity goes here
        //.
        //.
 
        // here, I am mapping the saved entity to dto 
        var added = Mapper.Map<PersonDto>(person);
    
        // this is where I reference the route by it's name and construct the route parameters.
        var response = CreatedAtRoute(RoutesHelper.RouteNames.People, new { id = added.Id }, added);
    
        return response;
    }
