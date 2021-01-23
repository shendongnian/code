     [HttpPost]
            public ActionResult   getValues(ModelClass mClass)
            {
                mClass.userName = "Hi!!, I am Sagar";
                return Content(mClass);
            }
