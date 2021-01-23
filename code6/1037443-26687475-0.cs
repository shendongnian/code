     [HttpPost]
        [Authorize(Roles = "YourRole")]
        [InitializeSimpleMembership]
        public ActionResult Create(Product p)
        {
            ...
        }
        
        @if (User.IsInRole("YourRole"))
        {
            @Html.ActionLink("Create Product", "Create")
        }
