    [HttpPost]
    public string Edit(MyViewModel model)
    {
        return Helper.ToJson(model.AVC);
    }
