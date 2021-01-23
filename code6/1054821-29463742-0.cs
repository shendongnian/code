    public class BaseCommandController : Controller
    {
        protected IMediator Mediator { get { return DependencyResolver.Current.GetService(typeof (IMediator)) as IMediator; } }
        public async virtual Task<ActionResult> BaseDoStuff<TCommand>(TCommand command, Func<ActionResult> success, Func<ActionResult> failure)
        {
            if (!ModelState.IsValid)
            {
                return failure();
            }
            var result = await Mediator.ProcessCommand(command);
            if (!result.IsSuccess())
            {
                AddErrorsToModelState(result);
                return failure();
            }
            return success();
        }
        private void AddErrorsToModelState(IResponse result)
        {
        }
    }
