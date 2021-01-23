    public void SaveContent(Expression<Func<CorePage, string>> propertyToSet, string contentToUpdate)
    {
        var page = Session.Load<CorePage>("CorePages/1");
        var memberExpression = (MemberExpression) propertyToSet.Body;
        var property = (PropertyInfo) memberExpression.Member;
        property.SetValue(page, contentToSet);
        RavenSession.SaveChanges();
    }
