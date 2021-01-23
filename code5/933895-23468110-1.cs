    [Route("api/inviteuser/{model}")]
    [HttpPut]
    public HttpResponseMessage InviteUser(Object model)
    {
        var jsonString = model.ToString();
        InviteUserModel result = JsonConvert.DeserializeObject<InviteUserModel>(jsonString);
    }
