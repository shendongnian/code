	public class UniqueAttribute<TEntity, TProperty> : ValidationAttribute
	{
	    private Expression<Func<TEntity, TProperty>> Selector { get; set; }
		
	    public UniqueAttribute(Expression<Func<TEntity, TProperty>> selector) {
			this.Selector = selector;
		}
		
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
			    ParameterExpression param = Selector.Parameters[0];
				Expression property = Selector.Body;
				Expression valueConst = Expression.Constant(value);
				Expression eq = Expression.Equal(property, valueConst);
				Expression<Func<TEntity, bool>> lambda = (Expression<Func<TEntity, bool>>) Expression.Lambda(eq, new ParameterExpression[]{param});
				
				Context db = new Context();
				if (db.Set<TEntity>.SingleOrDefault(lambda) != null)
				{
				return new ValidationResult(validationContext.DisplayName + " is already taken.");
				}
				return null;
			}
	}
