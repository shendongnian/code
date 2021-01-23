    public class DefaultController : BaseCommandController
    {
        protected async virtual Task<ActionResult> DoStuff(DoStuffAsyncCommand command)
        {
            return await BaseDoStuff(command, () => RedirectToAction("Index"), () => View(command));
        }
    }
