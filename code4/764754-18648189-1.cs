      [HttpPost]
      public ActionResult Update(Client client){
          //During model binding, validation is performed on client
          if(!ModelState.IsValid){
               return View(client);
          }
          return RedirectToAction("Index");
      }
