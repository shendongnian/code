    public class ViewModel
    {
      public int ddlSelectedValue {get; set;}
      List<System.Web.Mvc.SelectListItem> DDLItems { get; set; } //Instantiate this through Constructor    
    }
    ViewModel model = new ViewModel();
    
    int val = 5;
    model.DDLItems.Add( new SelectListItem() { Text = "Text", Value = Val.ToString() });
    
    return view (model)
    
    View
    @model NameSpace.ViewModel
    
    
    @Html.DropDownListFor(x => x.ddlSelectedValue, Model.DDLItems)
