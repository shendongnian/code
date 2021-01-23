    Expression<Func<Member, bool>> IsSearchable =  member => !member.IsPrivate
            && !String.IsNullOrEmpty(member.AboutMe)
            && !String.IsNullOrEmpty(member.ScreenName);
    
    Member currentUser = null;
    using (var container = new /**/())
    {
        var images = container.Members.Where(IsSearchable).SelectMany(member => member.Images);
        if (currentUser != null)
            images = images.Concat(currentUser.Images);
    
        var result = images.ToArray();
    }
