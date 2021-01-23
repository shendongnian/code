        public IHttpActionResult DoSomething(MyEntity myModel)
        {
            return InvokeWithExceptionHandler(
                () =>
                {
                    // ... Do controller things here
                    return View("MyView", myModel);
                });
        }
