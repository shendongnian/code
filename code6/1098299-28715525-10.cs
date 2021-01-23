    public JsonResult Delete([FromBody] Guid id)
        {
            try
            {
                _siteService.Delete(id); 
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error" + e.Message);
            }
    
        }
