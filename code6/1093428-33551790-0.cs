    @using System.Web.Mvc
    @model bool?
    @{
    var selectList = new List<SelectListItem>();
    selectList.Add(new SelectListItem { Text = "", Value = String.Empty,Selected = !Model.HasValue });
    selectList.Add(new SelectListItem { Text = "Yes", Value = "true",Selected = Model.HasValue && Model.Value });
    selectList.Add(new SelectListItem { Text = "No", Value = "false", Selected = Model.HasValue && !Model.Value });}
    @Html.DropDownListFor(m => m, selectList)
