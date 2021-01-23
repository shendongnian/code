    public ActionResult GetImage(Guid id){
       if(SomeFunctionToDetermineIfAllowed()){
           return new FileResult(...);
       }else{
           return RedirectToAction("NotFound");
       }
    }
