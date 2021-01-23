    public async Task<CarEnergy> Geter(int id)
    {
        string url = String.Format(Configuration.Configuration.GetCarEnergy, id);
        Debug.WriteLine(url);
        // Wait the get request before continue
        var myTask = await Get(url);
        Debug.WriteLine(result);
        var carEnergy = JsonConvert.DeserializeObject<List<CarEnergy>>(result);
        return carEnergy[0];
    }
