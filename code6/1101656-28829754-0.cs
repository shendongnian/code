    public static class Helper
    {
        public static ActionResult TryCatch(Func<ActionResult> funk)
        {
            try
            {
                if (funk != null)
                {
                    ActionResult result = funk();
                    if (result != null)
                        return result;
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
