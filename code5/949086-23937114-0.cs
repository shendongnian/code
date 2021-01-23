    public List<dynamic> ParseData(PausesByAgentModel model){
        List<dynamic> result = new List<dynamic>();
        foreach(String key in model.Keys){
            result.Add(new { pauses = key,value = model[key] });
        }
        
        return result;
    }
