    public ActionResult MyAction(object myResult)
            {
                if (condition)
                {
                    return RedirectToAction("OtherAction", "Controller2", myResult);
                }
                else
                {
                    return View();
                }
            }
