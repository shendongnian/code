	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Reflection;
	class Program
	{
		sealed class ReferencedPropertyFinder : ExpressionVisitor
		{
			private readonly Type _ownerType;
			private readonly List<PropertyInfo> _properties = new List<PropertyInfo>();
			public ReferencedPropertyFinder(Type ownerType)
			{
				_ownerType = ownerType;
			}
			public IReadOnlyList<PropertyInfo> Properties
			{
				get { return _properties; }
			}
			protected override Expression VisitMember(MemberExpression node)
			{
				var propertyInfo = node.Member as PropertyInfo;
				if(propertyInfo != null && _ownerType.IsAssignableFrom(propertyInfo.DeclaringType))
				{
					// probably more filtering required
					_properties.Add(propertyInfo);
				}
				return base.VisitMember(node);
			}
		}
		private static IReadOnlyList<PropertyInfo> GetReferencedProperties<T, U>(Expression<Func<T, U>> expression)
		{
			var v = new ReferencedPropertyFinder(typeof(T));
			v.Visit(expression);
			return v.Properties;
		}
		sealed class TestEntity
		{
			public int PropertyA { get; set; }
			public int PropertyB { get; set; }
			public int PropertyC { get; set; }
		}
		static void Main(string[] args)
		{
			Expression<Func<TestEntity, int>> expression =
				e => e.PropertyA + e.PropertyB;
			foreach(var property in GetReferencedProperties(expression))
			{
				Console.WriteLine(property.Name);
			}
		}
	}
