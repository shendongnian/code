    var portfolio = _db.Users
                       .Where(u => u.UserName == userName)
                       .Select(u =>u.Portfolio)
                       .FirstOrDefault();
    if(portfolio == null)
            {
                return HttpNotFound();
            }//end of if
            return View(portfolio);
