     // Verification Code Expired
     if ((DateTime)Session["VerificationTime"]).AddMinutes(1) < DateTime.Now)
     {
           ModelState.AddModelError("VerificationCode", "Verification Code Expired!");
           return View(adminLogin);
     }
     // Verification Code Error
     if (Session["VerificationCode"].ToString().ToUpper() != adminLogin.VerificationCode.ToUpper())
     {
           ModelState.AddModelError("VerificationCode", "Verification Code Error");
           return View(adminLogin);
     }
            
