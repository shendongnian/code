    {                      // Expression.Block(
        int result;        //   new[] { result },
        result = 1;        //   Expression.Assign(result, Expression.Constant(1)),
        while (true)       //   Expression.Loop(
        {                  
            if (value > 1) //     Expression.IfThenElse(
            {              //       Expression.GreaterThan(value, Expression.Constant(1)),
                result *=  //       Expression.MultiplyAssign(result,
                  value--; //       Expression.PostDecrementAssign(value)),
            }
            else             
            {
                break;     //       Expression.Break(label, result)
            }              //     ),
        }                  //   label)
    }                      // )
        
