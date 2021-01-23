    @model xxx_website.Models.MyModel
    @{
        ViewBag.Title = "Home Page";
     }
     @using (Html.BeginForm("Create", "Home", FormMethod.Post))
     {
         for (int i = 0; i< Model.MyItems.Count; i++)
         {
            @Html.EditorFor(model => model.MyItems[i].Name)
         }
         <input type="submit" value="Submit" />
     }
