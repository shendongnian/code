    public ActionResult AjaxAction(int Id)
            {
                if (Request.IsAjaxRequest())
                {
                    if (Id== 1)
                    {
                        ViewBag.SourceTypeId = new SelectList(db.SourceTypes, "Id", "Title");
                        ViewBag.CityId = new SelectList(db.Cities, "Id", "Title");
                        return PartialView("_CreateStatya");
                    }
                }
                return PartialView();
            }
