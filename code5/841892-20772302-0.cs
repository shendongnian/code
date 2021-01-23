	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
						
	public class Program
	{
		public void Main()
	    {
			var list = new List<Customer>();
			list.Add(new Customer(){
				FirstName = "ztest",
				LastName = "ztest1"
			});
			list.Add(new Customer(){
				FirstName = "test",
				LastName = "test1"
			});
			
			string sortExpressionField = "FirstName";
			
			var param = Expression.Parameter(typeof(Customer), sortExpressionField);
	        var sortExpression = Expression.Lambda<Func<Customer, object>>(
	                Expression.Convert(Expression.Property(param, sortExpressionField),typeof(object)), param);
			
			var sorted = list.AsQueryable<Customer>().OrderBy(sortExpression);
			foreach(var item in sorted)
			{
				Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
			}
	    }
	}
	public class Customer
	{
		public string FirstName {get;set;}
		public string LastName {get;set;}
	}
