	public class UniqueAttribute 
		{
		    private LambdaExpression Selector { get; set; }
			private Type EntityType { get; set; }
		    public UniqueAttribute(LambdaExpression selector) {
				this.EntityType = selector.Parameters[0].Type;
				this.Selector = selector;
			}
			
	        private LambdaExpression GeneratePredicate(object value) {
	                ParameterExpression param = Selector.Parameters[0];
					Expression property = Selector.Body;
					Expression valueConst = Expression.Constant(value);
					Expression eq = Expression.Equal(property, valueConst);
					LambdaExpression predicate = Expression.Lambda(eq, new ParameterExpression[]{param});
					
	                return predicate;
	        }
			
			private TEntity SingleOrDefault<TEntity>(IQueryable<TEntity> set, LambdaExpression predicate) {
				Type queryableType = typeof(Queryable);
				IEnumerable<MethodInfo> allSodAccessors = queryableType.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(x => x.Name=="SingleOrDefault");
				MethodInfo twoArgSodAccessor = allSodAccessors.Single(x => x.GetParameters().Length == 2);
				MethodInfo withGenArgs = twoArgSodAccessor.MakeGenericMethod(new []{typeof(TEntity)});
				
				return (TEntity) withGenArgs.Invoke(null, new object[]{set, predicate});
			}
	
			protected override ValidationResult IsValid(object value, ValidationContext validationContext)
				{
				    
					Context db = new Context();
					if (SingleOrDefault(db.Set(EntityType), GeneratePredicate(value)) != null)
					{
						return new ValidationResult(validationContext.DisplayName + " is already taken.");
					}
					return null;
				}
		}
