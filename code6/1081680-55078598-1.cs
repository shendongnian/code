    [HttpPost]
    public async Task<ActionResult<Client>> Post(Object model)
    {
       var clientString = model.ToString();
       Client client = JsonConvert.DeserializeObject<Client>(clientString, new ClaimConverter());
    }
