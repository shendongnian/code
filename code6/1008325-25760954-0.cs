    [HttpGet]
    public ActionResult Edit(Int32 id)
    {
      PersonBO objPerson = null;
      using (PersonClient Jclient = new PersonClient())
      {
          objPerson= Jclient.GetPersonById(id);
      }
      if (objPerson != null) 
      {
         return View(objPerson);
      } else {
         return View("NotFound");
      }
    }
