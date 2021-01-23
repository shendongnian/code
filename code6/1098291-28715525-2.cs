    public JsonResult Delete([FromUri] Guid id)
            {
                try{
                    _siteService.Delete(convertedID); 
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json("Error" + e.Message);
                }
        
            }
