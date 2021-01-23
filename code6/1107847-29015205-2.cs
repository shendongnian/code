    [HttpPost]
    public JsonResult createNewStatus(string description)
    {
        INV_Statuses status = new INV_Statuses()
        {
            // ID auto-set during save
            status_description = description,
            created_date = DateTime.Now,
            created_by = System.Environment.UserName
        };
        //var allErrors = ModelState.Values.SelectMany(x => x.Errors);
        try
        {
            var existingStatus = db.INV_Statuses.FirstOrDefault(x => x.status_description == status.status_description);
            var isDescriptionExisting = existingStatus != null;
            
            if(isDescriptionExisting)
            {
                ModelState.AddModelError("error", "value already exists and to choose it from the DropDownList");
            }
            else if (ModelState.IsValid)
            {
                db.INV_Statuses.Add(status);
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        }
        return Json(new { ID = status.Id, Text = status.status_description }, JsonRequestBehavior.AllowGet);
    }
