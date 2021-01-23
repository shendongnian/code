    // GET: /Checkout/Complete
    [Authorize]
    public ActionResult Complete(int id)
    {
         if (id == WebSecurity.CurrentUserId)
         {
         //do stuff
         }
         else {
         //tell user to not do that
         }
    }
