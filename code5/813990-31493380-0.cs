    @{
       IEnumerable<MyItemType> CDrop = ViewBag.Cat;
        
        
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var c in CDrop)
            {
                SelectListItem i = new SelectListItem();
                i.Text = c.Decsription.ToString();
                i.Value = c.TypeID.ToString();
                selectList.Add(i);
            }
        
    }
    
    }
    
        then some where in your view. 
        
        @Html.DropDownList("name", new SelectList(selectList, "Value","Text"));
        
