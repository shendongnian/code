    protected override Expression VisitMember(MemberExpression node)
    {    
        if (node.Member.MemberType == MemberTypes.Property)
        {
           var memberName = node.Member.Name;
           PropertyInfo otherMember = _type.GetProperty(memberName);
           var ncols = node.Member.GetCustomAttributes(typeof(NColumn), true);
           if (ncols.Any())
           {
              var ncol = (NColumn)ncols.First();
              otherMember = _type.GetProperty(ncol.Name);
           }
        
           var inner = Visit(node.Expression);
           return Expression.Property(inner, otherMember);
        }
        if (node.Member.MemberType == MemberTypes.Field)
        {
           if (node.Expression is ConstantExpression)
           {
              var owner = ((ConstantExpression)node.Expression).Value;
              var value = Expression.Constant(((FieldInfo)node.Member).GetValue(owner));
              return value;
           }
        }
        
        return base.VisitMember(node);
    }
