    public class ExpressionReplacer : ExpressionVisitor
    {
    	private readonly Func<Expression, Expression> replacer;
    
    	public ExpressionReplacer(Func<Expression, Expression> replacer)
    	{
    		this.replacer = replacer;
    	}
    
    	public override Expression Visit(Expression node)
    	{
    		return base.Visit(replacer(node));
    	}
    }
