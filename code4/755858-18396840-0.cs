    public enum CityType
        {
            [Description("Select City")]
            Select = 0,
    
            [Description("A")]
            NewDelhi = 1,
    
            [Description("B")]
            Mumbai = 2,
    
            [Description("C")]
            Bangalore = 3,
    
            [Description("D")]
            Buxar = 4,
    
            [Description("E")]
            Jabalpur = 5
        }
    
    IList<SelectListItem> list = Enum.GetValues(typeof(CityType)).Cast<CityType>().Select(x =>    new SelectListItem(){ 
        Text = EnumHelper.GetDescription(x), 
        Value = ((int)x).ToString()
    }).ToList(); 
    
        int city=0; 
        if (userModel.HomeCity != null) city= (int)userModel.HomeCity;
    ViewData["HomeCity"] = new SelectList(list, "Value", "Text", city);
    
    
     @Html.DropDownList("HomeCity",null,new { @style = "width:155px;", @class = "form-control" })
