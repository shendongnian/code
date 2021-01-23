    public async Task<ActionResult> GetData()
    {
        var data = new GetDemData();
        // fill data with addresses
        var task = data.CollectData();
        await task;
        return View();
    }
