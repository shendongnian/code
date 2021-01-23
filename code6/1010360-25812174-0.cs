                    foreach (User us in listaUsers)
                    {
                       
                            <option value="@us.UserID">@us.Name</option>
                        
                    }
                
            </select>
			
			
		/// Name fuction its like name of view for binding this part go to the controller
		public ActionResult anytingName()
        {
			User us= new User();
			us.Name="paul";
			us.UserID=1;
			List<User> users= new List<User>();
			users.Add(us);
            ViewBag.ListUser = users;
            return View();
        }
