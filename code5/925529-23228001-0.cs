    // User -> Receipt validation
            private bool canUserAccessReceipt(int aID)
            {
                int userID = WebSecurity.GetUserId(User.Identity.Name);
    
                int aFound = db.As.AsNoTracking().Where(x => x.aID == aID && x.UserID==userID).Count();
                if (aFound> 0)
                {
                    return true;
                }
                return false;
            }
