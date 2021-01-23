    @model Apps4KidsWeb.Models.AddAppViewModel
    
    @{
        ViewBag.Title = "Add App";
        ViewBag.CurrentPage = "Add App";
    }
    <div class="float">
        <h3>Categories</h3>
        <div id="categories">
            @Html.Partial("_Categories", Model)
        </div>
    
    
    
        @using (Ajax.BeginForm("AddCategory", "Admin",
        new AjaxOptions() { HttpMethod = "POST", UpdateTargetId = "categories", InsertionMode = InsertionMode.Replace }))
        {
            @Html.HiddenFor(model => model.Guid)
            @Html.EditorFor(model => model.Category)
            <input type="submit" value="Add" />    
        }
    </div>
    <div class="float">
        <h3>Operating Systems</h3>
        <div id="operatingSystems">
            @Html.Partial("_OperatingSystems", Model)
        </div>
    
        @using (Ajax.BeginForm("AddOperatingSystem", "Admin",
        new AjaxOptions() { HttpMethod = "POST", UpdateTargetId = "operatingSystems", InsertionMode = InsertionMode.Replace }))
        {
            @Html.HiddenFor(model => model.Guid)
            @Html.EditorFor(model => model.OS)
            <input type="submit" value="Add" />  
        }
    </div>
    <div class="clear"></div>
    @using (Html.BeginForm("AddApp", "Admin"))
    {
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)
    
        @Html.HiddenFor(model => model.Guid)
            
        @Html.EditorForModel()
    
        <p>
            <input type="submit" value="Weiter" />
        </p>
        
    }
    
    
    
    @section Scripts {
        @Scripts.Render("~/bundles/jqueryval")
    }
