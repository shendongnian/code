        public ActionResult MyMethod()
        {
            var model = new MyModel();
            if (TryUpdateModel(model, new FormValueProvider(this.ControllerContext)))
            {
                //proceed with post action                
            }
            //validation errors, display same form
            return View(model);
        }
