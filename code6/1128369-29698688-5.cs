    public ActionResult Join(int? id){
      Func<ActionResult> ifNotNull = () => {
        //do whatever you want here, in your case
        return View();
      }
      return isNull(id, ifNotNull);
    }
