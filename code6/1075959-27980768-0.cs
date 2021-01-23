    [HttpPost]
    public JsonResult Create(DTO incomingModel)
    {  
        if (ModelState.IsValid)
        {
            try
            {
                _nriRepository.Insert(incomingModel);                    
            }
            catch (Exception ex)
            {
                var x = new
                {
                    status = "Failed",
                    message = ex.Message,
                };
                return this.Json(x);
            }         
        }
        var x = new
        {
            status = "Success",
            message = "",
        };
        return this.Json(x);
    }
