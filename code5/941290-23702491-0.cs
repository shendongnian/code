       public ActionResult Create()
       {
        var model = Mapper.Map<DocumentType, DocumentTypeViewModel>(new DocumentType());
        Viewbag.List=Userlist// bind your list here
        return View(model);
       }
