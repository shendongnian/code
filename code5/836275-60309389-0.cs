static T Deserialize<T>(string json)
{
    return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
    {
        ContractResolver = new LongNameContractResolver()
    });
}
