    public ActionResult GridSave (FormCollection data) {
        try {
            ...
            return new EmptyResult();
        } catch (Exception ex) {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                                            "System Error: " + ex.Message);
        }
    }
