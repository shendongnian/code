    public ActionResult Edit(Guid id)
    {
        AVC avc = DatabaseManager.GetAVC(id); //get avc by id
    
        List<MemberKommun> kommuns = DatabaseManager.GetMemberKommuns(); //get all MemberKommuns
    
        //turn list into list of listItems for the drop down control
        List<SelectListItem> listItems = new List<SelectListItem>();
        for (int i = 0; i < kommuns.Count; i++)
        {
            listItems.Add(new SelectListItem()
            {
                Selected = kommuns[i].Id == avc.MemberKommunId,
                Text = kommuns[i].Name,
                Value = kommuns[i].Id.ToString(),
            });
        }
    
        var model = new MyViewModel();
        model.AVC = avc;
        model.Items = listItems;
        return View(model);
    }
