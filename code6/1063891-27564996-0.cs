      public virtual JsonResult GetCountryStates()
            {
                return Json(
                    new
                    {
                        new List<SelectListItem>() {YOUR ITEMS HERE}
                    });
            }
