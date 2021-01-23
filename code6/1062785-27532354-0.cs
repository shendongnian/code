            // (a, b => 
            // {
            //      if(a > b)
            //          return a;
            //      else
            //          return b;
            // }
            var a = Expression.Parameter(typeof(int), "a");
            var b = Expression.Parameter(typeof(int), "b");
            var returnLabel = Expression.Label(typeof (int));
            Expression<Func<int, int, int>> returnMax = (Expression<Func<int, int, int>>)Expression.Lambda
                (
                    Expression.Block
                    (
                        Expression.IfThenElse
                        (
                            Expression.GreaterThan(a, b),
                            Expression.Return(returnLabel, a),
                            Expression.Return(returnLabel, b)
                        ),
                        Expression.Label(returnLabel, Expression.Constant(0))
                    ),
                    a,
                    b
                );
            var shouldBeSix = returnMax.Compile()(5, 6);
