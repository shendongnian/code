    public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result) 
    {
        if (binder.Operation == System.Linq.Expressions.ExpressionType.Equal) { ... }
        return base.TryBinaryOperation(binder, arg, out result);
    }
