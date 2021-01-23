    using Newtonsoft.Json;
    ...
    public async Task<string> GetComplexModelList(){
        return JsonConvert.SerializeObject(new List<ComplexModel>())
    }
