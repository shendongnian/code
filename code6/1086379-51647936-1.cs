    public ActionResult MyAction()
        {
           // Your code
            return RedirectToAsyncAction<MyController>(c => c.MyAsyncAction(params,..)); // no warnings here
        }
