        //Original method
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        //My method
        private void AddLocalizedErrors(IdentityResult result, ApplicationUser user)
        {
            foreach (var error in result.Errors)
            {
                var localizedError = error;
                string userName = "";
                string email = "";
                if (user != null) 
                {
                    userName = user.UserName;
                    email = user.Email;
                }
                //password errors
                localizedError = localizedError.Replace("Passwords must have at least one uppercase ('A'-'Z').", AspNetValidationMessages.password_uppercase);
                localizedError = localizedError.Replace("Passwords must have at least one digit ('0'-'9').", AspNetValidationMessages.password_digit);
                localizedError = localizedError.Replace("Passwords must have at least one lowercase ('a'-'z').", AspNetValidationMessages.password_lowercase);
                localizedError = localizedError.Replace("Passwords must have at least one non letter or digit character.", AspNetValidationMessages.password_nonletter_nondigit);
                localizedError = localizedError.Replace("Passwords must have at least one non letter or digit character.", AspNetValidationMessages.password_nonletter_nondigit); 
                localizedError = localizedError.Replace("Passwords must have at least one non letter or digit character.", AspNetValidationMessages.password_nonletter_nondigit); 
                //register errors
                localizedError = localizedError.Replace("Name "+userName+" is already taken.", AspNetValidationMessages.name_taken.Replace("{0}", userName));
                localizedError = localizedError.Replace("Email '" + email + "' is already taken.", AspNetValidationMessages.email_taken.Replace("{0}", email)); 
                ModelState.AddModelError("", localizedError);
            }
        }
