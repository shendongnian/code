      static void AssignAndDoSomething<T>(T curr, T prev, Expression<Func<bool>> assign)
      {
        var logExpr = assign.Body as System.Linq.Expressions.BinaryExpression;
        //output rid of the first parameter
        Console.WriteLine(logExpr.Left);
        //output rid of the second parameter
        Console.WriteLine(logExpr.Right);
        //assign first parameter
        Expression.Lambda<Action>(Expression.Assign(logExpr.Left, Expression.Constant(curr))).Compile()();
        //assign second parameter
        Expression.Lambda<Action>(Expression.Assign(logExpr.Right, Expression.Constant(prev))).Compile()();
      }
      class A
      {
        public int P1;
      }
      class B
      {
        public int P1;
      }
      var a = new A();
      var b = new B();
      AssignAndDoSomething(a.P1, b.P1, () => b.P1 == a.P1);
