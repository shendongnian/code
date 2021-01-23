        public ActionResult MyMethod(FormCollection formData)
        {
            var model = new MyModel();
            if (TryUpdateModel(model, formData))
            {
                //proceed with post action                
            }
            //validation errors, display same form
            return View(model);
        }
