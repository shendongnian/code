    public static string MyFunc( Expression<Func<Student, object>> Property )
    {
         if ( Property != null && Property.Body != null )
             if ( Property.Body.NodeType == ExpressionType.MemberAccess )
             {
                 MemberExpression memberExpression = 
                    (MemberExpression)Property.Body;
 
                 if ( !string.IsNullOrEmpty( memberExpression.Member.Name ) )
                     return memberExpression.Member.Name;
                                
             }
 
         return string.Empty;
     }
