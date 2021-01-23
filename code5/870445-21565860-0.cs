    [HttpPost]
    [Route("api/Departments/PostDepartment/{accountid}/{name}/{dbContext=03}")]
    public void PostDepartment(string accountid, string name, string dbContext)
    {
        _deptsRepository.PostDepartment(accountid, name, dbContext);
    }
