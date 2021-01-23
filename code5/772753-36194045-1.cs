    <form action="Save" method="post">
     IsActive <input type="checkbox" id="IsActive" checked="checked" value="true" name="IsActive"  />
    
     </form>
    
     public ActionResult Save(Director director)
            {
                       // IsValid is my Director prop same name give    
                if(ModelState.IsValid)
                {
                    DirectorVM ODirectorVM = new DirectorVM();
                    ODirectorVM.SaveData(director);
                    return RedirectToAction("Display");
                }
                return RedirectToAction("Add");
            }
