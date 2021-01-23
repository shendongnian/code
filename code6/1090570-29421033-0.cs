    public override DbExpression Visit(DbScanExpression expression)
    {
        var table = expression.Target.ElementType as EntityType;
        if (table != null && table.Name == "User")
        {
            return expression.InnerJoin(
                DbExpressionBuilder.Scan(expression.Target.EntityContainer.BaseEntitySets.Single(s => s.Name == "TennantUser")),
                (l, r) =>
                    DbExpressionBuilder.Equal(
                        DbExpressionBuilder.Property(l, "UserId"),
                        DbExpressionBuilder.Property(r, "UserId")
                    )
            )
            .Select(exp => 
                new { 
                    UserId = exp.Property("l").Property("UserId"), 
                    Email = exp.Property("l").Property("Email") 
                });
        }
        return base.Visit(expression);
    }
