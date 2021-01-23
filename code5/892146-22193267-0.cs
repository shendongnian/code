    public static MemberInfo GetMemberInfo<T, TU>(Expression<Func<T, TU>> expression)
    {
        var member = expression.Body as MemberExpression;
        if (member != null)
        {
            // Getting the parameter's actual type, and retrieving the PropertyInfo for that type.
            return expression.Parameters.First().Type.GetProperty(member.Member.Name);
        }
        throw new ArgumentException("Expression is not a member access", "expression");
    }
