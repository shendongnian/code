            [HttpGet]
            public ActionResult Edit(int id)
            {
                DbUser editedDbUser = context.Users.Single(x => x.UserId == id);
                User editeduser = Mapper.Map<DbUser, User>(editedDbUser);
                return View("AccountInfo", editeduser);
            }
