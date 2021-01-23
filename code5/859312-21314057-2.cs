    [Authorize]
    [HttpPost]
    public ActionResult Perishable(MyViewModel model, string itemsJson)
    {
        if (ModelState.IsValid)
        {
            model.itemsModel= new ItemsModel
            {
                items= JsonConvert.DeserializeObject<List<string>>(itemsJson)
            };
    
            ...
        }
    }
