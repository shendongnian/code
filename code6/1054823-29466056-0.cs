    public async virtual Task<ActionResult> DoStuff(DoStuffAsyncCommand command)
    {
        return await ControllerHelper.Helper(ModelState, RedirectToAction( MVC.HomePage.Index()));
    }
    public static class ControllerHelper<T>
    {
        public static async Task<ActionResult> Helper(
            ModelStateDictionary ModelState, ActionResult returnAction)
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
