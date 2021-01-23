    public interface IHqlGeneratorForMethod
    {
        IEnumerable<MethodInfo> SupportedMethods { get; }
        HqlTreeNode BuildHql(MethodInfo method, Expression targetObject
              , ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder
              , IHqlExpressionVisitor visitor);
    }
