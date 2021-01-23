     [HttpPost]
        [InitializeSimpleMembership]
        [Authorize(Roles = "YourRole")]        
        public ActionResult Create(Product p)
        {
            ...
        }
        
        @if (User.IsInRole("YourRole"))
        {
            @Html.ActionLink("Create Product", "Create")
        }
