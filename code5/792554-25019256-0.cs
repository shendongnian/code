        public ActionResult Edit(int id)
            {
        Book book = _bookRepository.GetBookByID(id);
        return View(book);
        }  
         [HttpPost]
        public ActionResult Edit(Book book)
        {
          try
           {
             if (ModelState.IsValid)
              {
               _bookRepository.UpdateBook(book);
               _bookRepository.Save();
               return RedirectToAction("Index");
              } 
             }
              catch (DataException)
              {               
               ModelState.AddModelError("", "Unable to save changes. Try again, " + 
               "and if the problem persists see your system administrator.");
            }
                return View(book);
           }
