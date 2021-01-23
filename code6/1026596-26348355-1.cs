    [HttpPost]
            public ActionResult Edit(UserProfile userprofile, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fieldname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // Get the userprofile
                UserProfile user = db.userProfiles.FirstOrDefault(u => u.UserName.Equals(username));
                // Update fields
                user.Image = new byte[file.ContentLength];
                file.InputStream.Read(user.Image,0, file.ContentLength);
                user.FirstName = userprofile.FirstName;
                user.LastName = userprofile.LastName;
                user.Email = userprofile.Email;
                user.Motto = userprofile.Motto;
                user.PlaceOfBirth = userprofile.PlaceOfBirth;
                user.HowManyBikes = userprofile.HowManyBikes;
                user.BesideYourBeth = userprofile.BesideYourBeth;
                user.NicestRide = userprofile.NicestRide;
                user.WorstRide = userprofile.WorstRide;
                user.AmountKmPerYear = userprofile.AmountKmPerYear;
                user.AverageSpeed = userprofile.AverageSpeed;
                user.AbleToChatWhileRiding = userprofile.AbleToChatWhileRiding;
                user.PhoneNumber = userprofile.PhoneNumber;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Account");
            }
            return View(userprofile);
        }
