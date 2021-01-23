		Equals
	}
	
	public class Ops
	{
		public Type OperandType {get; set;}
		
		public OpType OpType {get; set;}
		
		public string OperandName {get;set;}
		
		public object ValueToCompare {get;set;}
		
		public MethodInfo TransformationMethod{get;set;}
	}
	
	public class TestClass
	{	
		public int ID {get;set;}
		public string Name {get; set;}
		public DateTime Date {get;set;}
	}
	
	public class ExpressionBuilder
	{
		public static Func<T,bool> BuildExpressions<T>( List<Ops> opList)
		{
			Expression currentExpression= null;
			var parameter = Expression.Parameter(typeof(T), "prop");
			for(int i =0; i< opList.Count; i++)
			{
				var op =  opList[i];
				Expression innerExpression = null;
				switch(op.OpType)
				{
					case OpType.Equals :
					{
						var innerParameter = Expression.Property(parameter,op.OperandName);
						//Console.WriteLine(innerParameter);
						var ConstExpression = Expression.Constant(op.ValueToCompare);
						//Console.WriteLine(ConstExpression);
						if(op.TransformationMethod != null)
						{
							innerExpression = Expression.Equal(Expression.Call(op.TransformationMethod, new []{innerParameter}), 
															   Expression.Call(op.TransformationMethod, new []{ConstExpression}));
							//Console.WriteLine(innerExpression);
						}
						else
							innerExpression = Expression.Equal(innerParameter, ConstExpression);
						break;
					}
				}
				
				if (i >0)
				{
					currentExpression = Expression.And(currentExpression, innerExpression);
				}
				else
				{
					currentExpression = innerExpression;
				}
			}
			var lambdaExpression = Expression.Lambda<Func<T,bool>>(currentExpression, new []{parameter});
			//Console.WriteLine(lambdaExpression);
			return lambdaExpression.Compile() ;
		}
	}
