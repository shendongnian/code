    [HttpPost]
    public virtual IHttpActionResult Validate(ODataActionParameters parameters)
    {
    //First we check if the parameters are correct for the entire action method
        if (!ModelState.IsValid)
        {
             return BadRequest(ModelState);
        }
        else
        {
             //Then we cast our entity parameter in our entity object and validate
             //it through the controller's Validate<TEntity> method
             TEntity Entity = (TEntity)parameters[typeof(TEntity).Name];
             Validate(Entity, typeof(TEntity).Name);
             if (!ModelState.IsValid)
             {
                  return BadRequest(ModelState);
             }
             IEnumerable<string> uniqueFields = parameters["UniqueFields"] as IEnumerable<string>;
             bool result = Importer.Validate(Entity, uniqueFields);
             return Ok(result);
        }
    }
