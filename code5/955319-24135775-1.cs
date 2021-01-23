    public void ParseObject<T>(T model, params Expression<Func<<T,string>>[] exprs)
    {
       foreach(var e in exprs)
       {
          var string = (e.Compile())(model); // do whatever you want with string here
          var targetMember = ((System.Linq.Expressions.MemberExpression) e.Body).Member; // warning, this will only work if you're properly calling the ParseObject method with the exact syntax i note bellow, this doesn't check that you're doing nothing else in the expressions, writing a full parser is way beyond the scope of this question
         // targetMember.Name will contain the name of the property or field you're accessing
         // targetMember.ReflectedType will contain it's type
       }
    }
