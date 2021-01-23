    @model bool? 
    @using System.Web.Mvc   
    @{   
        var selectList = new List<SelectListItem>();  
        selectList.Add(new SelectListItem { Text = "Yes", Value = "true" }); 
        selectList.Add(new SelectListItem { Text = "No", Value = "false" });
    } 
    @Html.DropDownListFor(m => m, selectList, "")
