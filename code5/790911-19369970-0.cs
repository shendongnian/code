             if (ModelState.IsValid)
            {
             bool valid=true;
            if (Membership_BAL.UsernameExist(model.UserName.Username))
            {
                ModelState.AddModelError("CustomError", "Usename is taken");
                valid=false;
            }
            if (Membership_BAL.EmailExist(model.EmailAddress.EmailAddress))
            {
                ModelState.AddModelError("CustomError", "Email Address is taken");
                 valid=false;
            }
            if (
                !Membership_BAL.CamparaEmailAddress(model.EmailAddress.EmailAddress,
                    model.EmailAddress.ComfirmEmailAddress))
            {
                ModelState.AddModelError("CustomError", "Email Address must match");
                 valid=false;
            }
           if (!valid)
           {
              return view();
            }
            Membership_BAL.Register(model);
            // TODO: Redirect use to profile page
            return RedirectToAction("Index", "Home");
        }
