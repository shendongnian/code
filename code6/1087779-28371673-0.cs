    [Route("api/select/{fieldList}")]
    [HttpGet]
    public object Dynamic(string fieldList)
    {
        dynamic expando = new ExpandoObject();
        var dictionary = expando as IDictionary<string, Object>;
              
        string[] fields = fieldList.Split(',');
        foreach (var field in fields)
        {
            dictionary.Add(field, "code to get the field value goes here");
        }
        return expando;
    }
