        [HttpPost]
        public ActionResult Edit(PersonBO objPerson)
        {
            if (!ModelState.IsValid)
            { 
               return View(objPerson);
            }
            using (PersonClient PClient = new PersonClient())
            {
                 idRet = JClient.UpdatePerson(objPerson.Id,
                                              objPerson.Name,
                                              objPerson.LastName,
                                              objPerson.BirthdayDate);
            }
        }
