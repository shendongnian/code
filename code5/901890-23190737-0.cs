    You can try this method :
    //Controller : 
        
        using(MyContext context = new MyContext() )
        {
           IEnumerable<SelectListItem> listItems = context.PermissionType.Select( p => new SelectListItem{ Text = p.FieldNameFor , Value = p.FieldNameFor });
           ViewBag.myList = listItems;
    
       }
    
    
    
    /*
          Do other stuffs here and then return to View()
    */
    
    
    // In your view :
    
    @{
         IIEnumerable<SelectListItem> listItems = (IEnumerable<SelectListItem>)ViewBag.myList;
     }
    
    
    
      @Html.DropDownListFor("Name of DropDownList" , listItems )
                                                                                         
