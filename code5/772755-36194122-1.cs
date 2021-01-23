     public ActionResult Save(Director director)
            {
              // IsActive my model property same name give in cshtml
    //IsActive <input type="checkbox" id="IsActive" checked="checked" value="true" name="IsActive" 
                if(ModelState.IsValid)
                {
                    DirectorVM ODirectorVM = new DirectorVM();
                    ODirectorVM.SaveData(director);
                    return RedirectToAction("Display");
                }
                return RedirectToAction("Add");
            }
