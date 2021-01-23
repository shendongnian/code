       userRepository objRepository= new userRepository();
       public ActionResult Edit(int id)
        {
           return View(objRepository.FindBy(user => user.Id == id).FirstOrDefault());
        }
