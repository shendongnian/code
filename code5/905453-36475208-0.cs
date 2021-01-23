    @* Index.cshtml *@
        @using (Html.BeginForm())
        {
          <p>
          Find by name: @Html.TextBox("SearchString")
          <input type="submit" value="Search" />
          </p>
        }
        . . .
        <!-- header -->
        <table><tr><th>
          @Html.ActionLink("Last Name", "Index", new { sortOrder = ViewBag.NameSortParm })
        </th>
    
    . . .
        
    //controller.cs
        public ActionResult Index(string sortOrder, string searchString){...}
        
