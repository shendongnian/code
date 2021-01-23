    public JsonResult Delete([FromBody] Guid id)
        {
            try
            {
                var convertedID = new Guid(id);
                _siteService.Delete(convertedID); 
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error" + e.Message);
            }
    
        }
