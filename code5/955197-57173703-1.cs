public object Get([FromBody]object requestModel)
{
    var jsonstring = JsonConvert.SerializeObject(requestModel);
    RequestModel model = JsonConvert.DeserializeObject<RequestModel>(jsonstring);
}
