       void  CheckedOp (int a, int b, Expression <Action <int, int>> small, Action <int, int> big){
             var smallFunc = InjectChecked (small);
             try{
                   smallFunc(a, b);
             }catch (OverflowException oe){
                   big(a,b);
             }
       }
       Action<int, int> InjectChecked( Expression<Action<int, int>> exp )
       {
              var v = new CheckedNodeVisitor() ;
              var r = v.Visit ( exp.Body);
              return ((Expression<Action<int, int>> exp) Expression.Lambda (r, r. Parameters) ). Compile() ;
       }
       class CheckedNodeVisitor : ExpressionVisitor {
               public CheckedNodeVisitor() {
               }
               protected override Expression VisitBinary( BinaryExpression be ) {
                      switch(be.NodeType){
                            case ExpressionType.Add:   
                                    return Expression.AddChecked( be.Left, be.Right);
                      }
                      return be;
               }
       }
