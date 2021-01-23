    private User ModifyAndSave(Action<User> modify) {
        using (var db = _contextFactory.GetContext())
        {
            var currentUser = db.Users.Single(x => x.Login == Environment.UserName);
            modify(currentUser);
            db.SaveChanges();
            return currentUser;
        }
    }
    public User SaveBaselineModelTemplateId(int baselineModelTemplateId)
    {
         return ModifyAndSave(u => u.BaselineModelTemplateID = baselineModelTemplateId);
    }
    public User SaveComparisonModelTemplateId(int comparisonModelTemplateId)
    {
         return ModifyAndSave(u => u.ComparisonModelTemplateID = comparisonModelTemplateId);
    }
