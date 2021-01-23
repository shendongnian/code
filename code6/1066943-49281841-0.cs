    public JsonResult DoSomething() {
            try
            {
                
                var result = getData();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(HttpNotFound());
            }
            
        }
