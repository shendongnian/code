    public virtual ActionResult ListUser()
        {            
            var users = UserManager.Users;
            var roles = new List<string>();
            foreach (var user in users)
            {
                string str = "";
                foreach (var role in UserManager.GetRoles(user.Id))
                {
                    str = (str == "") ? role.ToString() : str + " - " + role.ToString();
                }
                roles.Add(str);
            }
            var model = new ListUserViewModel() {
                users = users.ToList(),
                roles = roles.ToList()
            };
            return View(model);
        }
