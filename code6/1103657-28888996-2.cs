    public abstract class BaseController : Controller
    {
        protected ActionResult HandleResponse(BaseResponse response, string redirectToAction)
        {
            if (response.IsSuccess) 
                return RedirectToAction(redirectToAction);
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return View();
        }
    }
