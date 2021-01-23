    @model MvcApplication1.Models.WomenList
    @{
        ViewBag.Title = "Home Page";
    }
    @section featured {
    }
    @using (Html.BeginForm("SaveWomens", "Home", FormMethod.Post))
    { 
        @Html.Partial("_Women", Model.Womens)
        
        <input type="submit" value="save" />
    }
