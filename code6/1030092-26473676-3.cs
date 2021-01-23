        public class CustomLikeGenerator : BaseHqlGeneratorForMethod
        {
            public CustomLikeGenerator()
            {
                this.SupportedMethods = new[]
                {
                    ReflectionHelper.GetMethodDefinition(
                        () => LinqExtensions.IsLikeWithEscapeChar(null, null, null))
                };
            }
            public override HqlTreeNode BuildHql(
                MethodInfo method,
                System.Linq.Expressions.Expression targetObject,
                ReadOnlyCollection<System.Linq.Expressions.Expression> arguments,
                HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
            {
                // Is there a better way to do this?
                var factory = new ASTFactory(new ASTTreeAdaptor());
                HqlTreeNode escapeCharNode = visitor.Visit(arguments[2]).AsExpression();
                var escapeNode = new HqlEscape(factory, escapeCharNode);
                HqlLikeWithEscape likeClauseNode =
                    new HqlLikeWithEscape(
                        factory,
                        visitor.Visit(arguments[0]).AsExpression(),
                        visitor.Visit(arguments[1]).AsExpression(),
                        escapeNode);
                return likeClauseNode;
            }
        }
    As you can see, we've utilized the new HQL tree nodes we defined earlier. The major downside to this approach is that it required me to manually create an `ASTFactory` and `ASTTreeAdaptor`. The use of these classes is usually encapsulated inside of `HqlTreeBuilder`, but `HqlTreeBuilder` doesn't lend itself to being subclassed. Would appreciate some input on this if someone has some advice.
