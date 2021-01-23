    public ActionResult foo(X x)
    {
        var a= /* select where First=x.First */
        if(a!=null)
        {
            ModelState.AddModelError(Params);
        }
        if (ModelState.IsValid)
        /* rest of the code */
    }
