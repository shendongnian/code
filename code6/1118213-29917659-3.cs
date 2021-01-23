     public static System.Func<%type of ra% ra, %status type%>
        GetStatusExpressionCompiled = GetStatusExpression.Compile();
     
     ...
     
     if (GetStatusExpressionCompiled(ra) == ...)
     {
       ...
