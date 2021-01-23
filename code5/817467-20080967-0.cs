    Expression callExpr = Expression.Call(
    typeof (decimal), "Contains", new[] {member.Type}, constant, param);
    
    public static bool Contains(this decimal obj, string value)
    {
       String _this = obj.ToString();
       return _this.Contains(value);
    }
