     public IHttpActionResult Post(Model model)
    {
        if (model == null) {
            return new ActionResponse("Invalid *** Info", HttpStatusCode.BadRequest, Request);
        }
        //Validating Model here (I did some validation here)
        string validationMessage = _ServiceManager.ValidateModel(model);
        if (!string.IsNullOrWhiteSpace(validationMessage)){
            return new ActionResponse(validationMessage, HttpStatusCode.BadRequest, Request);
        }
        //Perform your business Logic here...
        return new ActionResponse("Success", HttpStatusCode.Created, Request);
    }
