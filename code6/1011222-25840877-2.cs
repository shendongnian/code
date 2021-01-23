    @model IEnumerable<xxx_website.Models.MyModel>
    @{
        ViewBag.Title = "Home Page";
     }
     @using (Html.BeginForm("Create", "Home", FormMethod.Post))
     {
         foreach (var item in Model.MyItems)
         {
             @Html.EditorFor(model => item.Name)
         }
         <input type="submit" value="Submit" />
     }
