    public IEnumerable<SelectListItem> GetCarModels()
    {
        var list = new List<SelectListItem>();
    
        foreach (var car in GET_CARS())
        {
            list.Add(new SelectListItem()
                {
                    Value = car.Id.ToString(),
                    Text = car.model_name
                });
        }
    
        return list;
    }
