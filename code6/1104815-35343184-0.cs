    public IHttpActionResult Post(MyViewModel viewModel)
    {            
        if (!ModelState.IsValid)
        { 
            return Content(HttpStatusCode.BadRequest, ModelState); 
        }
        var modelMapper = new modelMapper();
        var model = modelMapper.getModelFromViewModel(viewModel);
        var modelRepository = new ModelRepository();
        modelRepository.Save(model);
        return Ok();
    }
