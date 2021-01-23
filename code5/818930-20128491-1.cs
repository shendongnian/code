    public ActionResult Detail(string Id)
    {
        int actualId;
        try{
           actualId = MyUtil.Decrypt(id);
        }catch(Exception e){
             //someone mucked with my encryption string
             RedirectToAction("SomeError", "Errors");
        }
        var employee = MyEmployeeService.GetEmployeeById(actualId);
        if(employee == null){
             //This was a bad id
             RedirectToAction("NotFound", "Errors");
        }
        Return View(employee);
    }
