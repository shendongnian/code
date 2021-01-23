    [HttpPost]
            public ActionResult SaveAction(myModel model)
            {
                if (model != null && ModelState.IsValid)
                {
                }
                return Json(new { IsValid = ModelState.IsValid });
            }
