    using Newsoft.Json;
    public JsonResult FunctionName(string JsonString)
    {
        if (JsonString!= null)
        {
            YourObject YourObjectInstance = new YourObject ();
            try
            {
                YourObjectInstance = JsonConvert.DeserializeObject<YourObject >(JsonString);
               //do something with the data                
               
               // return a Json response of either your object or another object type
               return Json(YourObjectInstance, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new JsonResult();  //return empty JsonResult
            }
            }
            else
            {
                return new JsonResult();  //return empty JsonResult
            }
        }
    }
