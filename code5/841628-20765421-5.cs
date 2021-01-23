    public class SecondController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SomeAction(SomeModel model)
        {
            if (ModelState.IsValid)
            {
                // Add to database, or whatever, and now redirect
                return RedirectToAction("Success");
            }
            // Redisplay the form if validation failed.
            return View(model);
        }
    }
