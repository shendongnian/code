    [Route("api/Messaging")]
    public void Post([FromBody]Message message)
    {
        message.Id = ObjectId.GenerateNewId().ToString();
        DataRepository.GetDataRepository().Save(message);
    
        DataRepository.PostOrUpdateThread(message);
    }
