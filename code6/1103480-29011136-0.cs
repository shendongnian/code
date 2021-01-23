    <span class=" col-md-10">
                @using (var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ViewBag.dbContext)))
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ViewBag.dbContext));
                    var allRoles = roleManager.Roles;
                    var userRoles = userManager.GetRoles(Model.Id);
                    foreach (var role in allRoles)
                    {
                        String check = userRoles.Contains(role.Name) ? "checked" : "";
                        <input type="checkbox" name="Roles" value="@role.Name" class="checkbox-inline" @check/>
                        @Html.Label(role.Name, new { @class = "control-label" })
                    }
                }
            </span>
