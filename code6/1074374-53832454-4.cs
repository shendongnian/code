    public async Task<ActionResult> Register()
		{
			var _roles = new List<SelectListItem>();
			_roles.Add(new SelectListItem
			{
			   Text = "Select",
			   Value = ""
			});
			foreach (var role in GetRoles())
			{
			  _roles.Add(new SelectListItem
			  {
				Text = z.Name,
				Value = z.Id
			  });
			}
			
			var model = new RegistrationViewModel
			{
				Roles = _roles
			};
			return View(model);
		}
