    public async virtual Task<ActionResult> DoStuff(DoStuffAsyncCommand command)
    {
        return await ControllerHelper.Helper(command, ModelState, _mediator,
             RedirectToAction(MVC.HomePage.Index()));
    }
    public static class ControllerHelper<T>
    {
        // You may need to constrain this to where T : class, didn't test it
        public static async Task<ActionResult> Helper<T>(T command,
            ModelStateDictionary ModelState, IMediator mediator, ActionResult returnAction)
        {
            if (!ModelState.IsValid)
            {
                return new ViewResult(command);
            }
    
            var result = await mediator.ProcessCommandAsync(command);
    
            if (!result.IsSuccess())
            {
                ModelState.AddErrorsToModelState(result);
                return new ViewResult(command);
            }
            return returnAction;
        }
        public void AddErrorsToModelState(this ModelStateDictionary ModelState, ...)
        {
            // add your errors to the ModelState
        }
    }
