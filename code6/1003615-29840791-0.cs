    [HttpPost]
    public ActionResult EditEmailTemplate(EmailTemplate_Mst emailTemplate_Mst, string Command, int id = 0)
    {
        try
        {
            EmailTemplate_Mst et = _repository.GetEmailById(id);
            if (Command == "Update")
            {
                et.Title = emailTemplate_Mst.Title;
                et.EmailTemplate_Content = emailTemplate_Mst.EmailTemplate_Content;
                et.EmailTemplate_LastModifyBy = Convert.ToInt64(Session["UserId"].ToString());
                et.EmailTemplate_LastModifyDate = DateTime.Now;
                _repository.UpdateEmail(et);
                return RedirectToAction("ViewEmailTemplate");
            }
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        }
        return View(new { id = emailTemplate_Mst.EmailTemplate_Id });
    }
