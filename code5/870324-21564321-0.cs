    public ActionResult GetUserInfo()
    {
        string userInfo = "";
        using (EntityObject db = new EntityObject())
        {
            var account = db.table_name.FirstOrDefault(u => u.UserID == User.Identity.Name);
            userInfo = account.UserDataToDisplay;
        }
        return Content(userInfo);
    }
