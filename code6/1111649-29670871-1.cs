    public class RandomOrderHqlGenerator : BaseHqlGeneratorForMethod
    {
    	private readonly string _name;
    	public RandomOrderHqlGenerator()
    	{
    		_name = "NewId";
    	}
    	public override HqlTreeNode BuildHql(MethodInfo method, System.Linq.Expressions.Expression targetObject, ReadOnlyCollection<System.Linq.Expressions.Expression> arguments,
    		HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    	{
    		return treeBuilder.MethodCall(_name);
    	}
    }
RegisterGenerator(ReflectionHelper.GetMethodDefinition(() => OrderType.Random(null)), new RandomOrderHqlGenerator());
