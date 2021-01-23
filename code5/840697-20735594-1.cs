    public List<KeyedList<string, Hspital>> GroupedHospitals
    {
        get
        {
            hspitalList= getJson().Result;
            ...
        }
    }
    ...
    public async Task<IList<Hspital>> getJson()
    {
       ....
       return JsonConvert.DeserializeObject<IList<Hspital>>(jsonContents) as List<Hspital>;
    }
