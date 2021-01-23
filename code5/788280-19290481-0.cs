    public ActionResult SomeControllerAction(UserViewModel user)
    {
        if (!ModelState.IsValid)
        {
            // at this point the human readable (and assuming < 20 length) password
            // would be getting validated
            return View(user);
        }
        // now when you're writing the record to the DB, encrypt the password
        var crypto = new SimpleCrypto.PBKDF2();
        var encryptedPass = crypto.Compute(user.Password);
        user.Password = encryptedPass;
        user.PasswordSalt = crypto.Salt;
        _db.Users.Add(user);
        _db.SaveChanges();
        // return or redirect to whatever route you need
    }
