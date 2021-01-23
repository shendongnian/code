    @{
        var ListInterest = new List<SelectListItem>() //hard-code, better load interests from db
    {
    new SelectListItem(){ Value = 1, Text="Stamp Collecting" },
    new SelectListItem(){ Value=2, Text="Listening to Music" },
    new SelectListItem(){ Value=3, Text="Reading"}
    }; 
    
    Html.ListBoxFor(c => c.Interests,
                    new MultiSelectList(ListInteres, "Value", "Text"))
