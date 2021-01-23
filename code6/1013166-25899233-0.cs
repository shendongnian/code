    public static string GetSettingName<TObject, TProperty>(this TObject settings, 
        Expression<Func<TObject, TProperty>> member) 
        where TObject : System.Configuration.ApplicationSettingsBase
    {
        var expression = (MemberExpression)member.Body;
        return expression.Member.Name;
    }
