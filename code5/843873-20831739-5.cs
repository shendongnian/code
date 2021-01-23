    public ActionResult EditSection(Int16 id = -1)
    {
        Section section = db.Sections.Find(id);
        if (section != null)
        {
           var vm=new SectionEditViewModel { Section=section};
           vm.Types=GetTypes(); 
           vm.SelectedType=section.Type;
           return View(vm);
        }
        return View("NotFound");        
    }
