    public ActionResult SomeControllerAction()
    {
      var jsonResult = Json(veryLargeCollection, JsonRequestBehavior.AllowGet);
      jsonResult.MaxJsonLength = int.MaxValue;
      return jsonResult;
    }
