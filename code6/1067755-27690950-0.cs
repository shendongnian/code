    [NullReferenceException: Object reference not set to an instance of an object.]
       MySql.Data.Entity.SqlGenerator.Visit(DbPropertyExpression expression) +18
       MySql.Data.Entity.SqlGenerator.Visit(DbInExpression expression) +39
       System.Data.Entity.Core.Common.CommandTrees.DbInExpression.Accept(DbExpressionVisitor`1 visitor) +64
       MySql.Data.Entity.SqlGenerator.VisitBinaryExpression(DbExpression left, DbExpression right, String op) +82
       MySql.Data.Entity.SqlGenerator.Visit(DbAndExpression expression) +49
       ...
