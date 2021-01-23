    public ActionResult GridSave (FormCollection data) {
        try {
            ...
            return new EmptyResult();
        } catch (Exception ex) {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return Content("System Error: " + ex.Message);
        }
    }
