    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    
    public class Test
    {
    	public static IEnumerable<T> SelectItems<T>(IEnumerable<T> items, string propName, string value)
    	{
    		IEnumerable<PropertyInfo> props;
    		if (!string.IsNullOrEmpty(propName))
    			props = new PropertyInfo[] { typeof(T).GetProperty(propName) };
    		else
    			props = typeof(T).GetProperties();
    		props = props.Where(x => x != null && x.PropertyType == typeof(string));
    		Expression lastExpr = null;
    		ParameterExpression paramExpr = Expression.Parameter(typeof(T), "x");
    		ConstantExpression valueExpr = Expression.Constant(value);
    		foreach(var prop in props)
    		{
    			var propExpr = GetPropertyExpression(prop, paramExpr, valueExpr);
    			if (lastExpr == null)
    				lastExpr = propExpr;
    			else
    				lastExpr = Expression.MakeBinary(ExpressionType.Or, lastExpr, propExpr);
    		}
    		if (lastExpr == null)
    			return new T[] {};
    		var filterExpr = Expression.Lambda(lastExpr, paramExpr);
    		return items.Where<T>((Func<T, bool>) filterExpr.Compile());
    	}
    	
    	private static Expression GetPropertyExpression(PropertyInfo prop, ParameterExpression paramExpr, ConstantExpression valueExpr)
    	{
    		var memberAcc = Expression.MakeMemberAccess(paramExpr, prop);
    		var containsMember = typeof(string).GetMethod("Contains");
    		return Expression.Call(memberAcc, containsMember, valueExpr);
    	}
    	
    	class TestClass
    	{
    		public string SomeProp { get; set; }
    		public string SomeOtherProp { get; set; }
    	}
    	
    	public static void Main()
    	{
    		var data = new TestClass[] {
    			new TestClass() { SomeProp = "AAA", SomeOtherProp = "BBB" }, 
    			new TestClass() { SomeProp = "BBB", SomeOtherProp = "CCC" }, 
    			new TestClass() { SomeProp = "CCC", SomeOtherProp = "AAA" }, 
    		};
    		var result = SelectItems(data, "", "A");
    		foreach(var item in result)
    			Console.WriteLine(item.SomeProp);
    	}
    }
