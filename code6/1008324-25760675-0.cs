    private Int32 EditPerson(PersonBO objPerson)
    {
      Int32 idRet = -1;
      try
      {
        using (PersonClient PClient = new PersonClient())
        {
          idRet = JClient.UpdatePerson(objPerson.Id,
            objPerson.Name,
            objPerson.LastName,
            objPerson.BirthdayDate);
        }
      }
      catch (Exception) 
      { 
      }    
      return idRet;
    }
    [HttpPost]
    public ActionResult Edit(PersonBO objPerson)
    {
        if (ModelState.IsValid && objPerson != null)
        {
            Int32 result = EditPerson(objPerson);
            if(result != -1)
            {
                return RedirectToAction("GetAll");
            }
            else 
            {
                ViewBag.Message = "Update failed!";
                return View(objPerson);
            }
        }
        else
        {
            ViewBag.Message = "Validation error!";
            return View(objPerson);
        }
    }
