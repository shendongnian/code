    [NonAction]
    private IEnumerable<SelectListItem> GetData()
    {
        return new List<SelectListItem>()
        {
            new SelectListItem(){ Text="--Select--", Value="0"},
            new SelectListItem(){ Text="A", Value="1"},
            new SelectListItem(){ Text="B", Value="2"},
            new SelectListItem(){ Text="C", Value="3"},
        };
    }
    
    Call this function in Action Method
    public ActionResult Create()
    {
        ViewData["categories"] = GetData();
        return View();
    }
    
    
    On your html page:
      <%= Html.DropDownList("cat", (IEnumerable<SelectListItem>)ViewData["categories"])%>
