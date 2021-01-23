    [Route("api/system-users/save-collection-async")]
    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]       
    public async Task<IActionResult> SaveSystemUserCollectionAsync([FromBody] GenericListContainer<SystemUser> dto)
    {
        var response = await _systemUserService.SaveSystemUserCollectionAsync(dto.List);
        return Ok(response);
    }
