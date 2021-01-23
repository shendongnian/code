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
            var existingStatus = db.INV_Statuses.FirstOrDefault(x => x.status_description.ToUpper() == status.status_description.ToUpper());
            var isDuplicateDescription = existingStatus != null;
            string error = String.Empty;
            if (isDuplicateDescription)
            {
               error = "[" + status.status_description + "] already exists in the database. Please select from the DropDownList.";
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
        return Json(new { ID = status.Id, Text = status.status_description, Error = error , IsDuplicate = isDuplicateDescription }, JsonRequestBehavior.AllowGet);
    }
