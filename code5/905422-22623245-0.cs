		[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
		public RedirectToRouteResult Default(
			[Bind(Prefix = "Credentials", Include = "Email,Password")] CredentialsInput credentials) {
			if (base.ModelState.IsValid
				&& this.AuthenticationService.SignIn(credentials)) {
				return this.RedirectToAction(
					c =>
						c.DefaultRedirect());
			}
			return this.RedirectToAction(
				c =>
					c.Default());
		}
		[HttpGet]
		public RedirectToRouteResult DefaultRedirect() {
			if (this.User.IsInRole("Technician")) {
				return this.RedirectToAction<TechniciansController>(
					c =>
						c.Default());
			}
			return this.RedirectToAction(
				c =>
					c.Dashboard());
		}
