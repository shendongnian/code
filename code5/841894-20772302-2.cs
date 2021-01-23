	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	public class Program
	{
		public static void Main()
		{
			var list = new List<Customer>();
			list.Add(new Customer()
			{
				FirstName = "ztest",
				LastName = "ztest1",
				Address = new Address()
				{
					City = "Kiev"
				}
			});
			list.Add(new Customer()
			{
				FirstName = "test",
				LastName = "test1",
				Address = new Address()
				{
					City = "New York"
				}
			});
			string sortExpressionField = "Address.City";
		    var props = sortExpressionField.Split('.');
		    var inParam = Expression.Parameter(typeof(Customer));
		    var param = props.Aggregate<string, Expression>(inParam, Expression.Property);
			var sortExpression = Expression.Lambda<Func<Customer, object>>(param, inParam);
			var sorted = list.AsQueryable<Customer>().OrderBy(sortExpression);
			foreach (var item in sorted)
			{
				Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
			}
		}
	}
	public class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Address Address { get; set; }
	}
	public class Address
	{
		public string City { get; set; }
	}
