    public List<SelectListItem> GetSelectList(DateTime? dateOfBirth)
        {
       var vtList = MetadataManager.GetValidationTypes().Where(x => x.DisplayInAdminTool).Select(x => x);
    
            List<SelectListItem> myList = new List<SelectListItem>();
             
            var items = (from n in vtList
                         select new SelectListItem
                         {
                           Text = vtitem.DisplayName,
                           Value = vtitem.ID.ToString()
                          }).ToList();
    
            foreach( var item in items)
              myList.Add(item);
    
              //I don't know, why you need this empty item:
             myList.Add(new SelectListItem() { Text = String.Empty, Value = String.Empty });
    
            if (dateOfBirth.HasValue)
            {
                if (dateOfBirth >= DateTime.Now.AddYears(-18))
                {
                     myList.Add(new SelectListItem() { Text = "Patient Face to Face Minor" });
                }
                else
                {
                     myList.Add(new SelectListItem() { Text = "Patient Face to Face" });
                     myList.Add(new SelectListItem() { Text = "Patient Phone" });
                     myList.Add(new SelectListItem() { Text = "Patient Notary" });
                }
    
            return myList; //or ViewBag.list = myList, if void()
        }
