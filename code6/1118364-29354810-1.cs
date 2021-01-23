    public JsonResult Machine()
        {
            string ip = Request.UserHostAddress;
            //Find the mapped name and return.
            //Need to add your logic here.
            return Json("Head Board Assembly", JsonRequestBehavior.AllowGet);
        }
