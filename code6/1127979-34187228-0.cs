     public override DbExpression Visit(DbScanExpression expression)
        {
            var table = expression.Target.ElementType as EntityType;
            if (table != null && table.Name == "User")
            {
                var rightExpression = expression.Target.EntityContainer.GetEntitySetByName("TennantUser", true).Scan();
                var join = expression.InnerJoin(rightExpression,
                    (l, r) =>
                            DbExpressionBuilder.Equal(
                                DbExpressionBuilder.Property(l, "UserId"),
                                DbExpressionBuilder.Property(r, "UserId")
                            ));
                var select = join.Select(exp => DbExpressionBuilder.NewRow(
                    expression.Target.ElementType.Members.Select(x => 
                        new KeyValuePair<string, DbExpression>(x.Name, exp.Property(join.Left.VariableName).Property(x.Name)))));
                return select;
               
            }
            return base.Visit(expression);
        }
