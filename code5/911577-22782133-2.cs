    [HttpPost]
    public ActionResult Login(LogIn model)
    {
        try
        {
            EntityConnection connection = connect.getConnection();
            Entities ctx = new Models.Entities(connection);
            connection.Open();
            connection.Close();
            if (true) // Logic to validate login
            {
                return Json(new { LoginResult = true, Redirect = RedirectToAction("Index", "HomePage") });
            }
            return Json(new { LoginResult = false });
        }
        catch (Exception ex)
        {
            return Json(ex);
        }
    }
