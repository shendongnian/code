    public async virtual Task<ActionResult> DoStuff(DoStuffAsyncCommand command)
    {
        return await ControllerHelper.Helper(command, ModelState, _mediator,
             RedirectToAction(MVC.HomePage.Index()), View(command), View(command));
    }
    public static class ControllerHelper
    {
        // You may need to constrain this to where T : class, didn't test it
        public static async Task<ActionResult> Helper<T>(T command,
            ModelStateDictionary ModelState, IMediator mediator, ActionResult returnAction, 
            ActionResult successAction, ActionResult failureAction)
        {
            if (!ModelState.IsValid)
            {
                return failureResult;
            }
    
            var result = await mediator.ProcessCommandAsync(command);
    
            if (!result.IsSuccess())
            {
                ModelState.AddErrorsToModelState(result);
                return successResult;
            }
            return returnAction;
        }
        public static void AddErrorsToModelState(this ModelStateDictionary ModelState, ...)
        {
            // add your errors to the ModelState
        }
    }
