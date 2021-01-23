    public static void DisplayVarName<T>(Expression<Func<T>> expression)
    {
        List<string> memberNames = new List<string>();
        MemberExpression memberExpression = 
            expression.Body as MemberExpression;
    
        do
        {
            memberNames.Add(memberExpression.Member.Name);
            memberExpression = 
                memberExpression.Expression as MemberExpression;                
        } while (memberExpression != null);
    
        memberNames.Reverse();
        Console.WriteLine(String.Join(".", memberNames));
    }
