    [HttpPost]
    public ActionResult CreateNewFunctionNavigation(CreateFunctionNavigation_SP model)
    {
        if (ModelState.IsValid)
        {
           //Validation passed, Save data or do soemthing
            return Json(new { IsSuccess = true });
        }
        else
        {
            //Validation failed. Let's get the error messages
            var errors =  ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0).ToList();
            var errorList=new List<string>();
            foreach (var err in errors)
            {
                errorList.AddRange(err.Select(errItem => errItem.ErrorMessage));
            }
            return Json(new { IsSuccess=false,Errors=errorList});
        }
    }
