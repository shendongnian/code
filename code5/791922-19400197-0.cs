	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Reflection;
	namespace TestsA
	{
		class TestLambdaExpression
		{
			class Inner { public int tata; }
			string toto;
			Inner tutu;
			static void Test3<T>(Expression<Func<T>> exp)
			{
				Expression body = exp.Body;
				List<string> memberNames = new List<string>();
				while(body.NodeType == ExpressionType.MemberAccess)
				{
					MemberExpression memberBody = (MemberExpression)body;
					memberNames.Add(memberBody.Member.Name);
					body = memberBody.Expression;
				}
				memberNames.Reverse();
				Console.WriteLine("Member: {0}", string.Join(".", memberNames));
			}
			public static void Test()
			{
				TestLambdaExpression obj = new TestLambdaExpression();
				obj.toto = "Hello world!";
				obj.tutu = new Inner();
				obj.tutu.tata = 42;
				Test3(() => obj.toto);
				Test3(() => obj.tutu.tata);
			}
		}
	}
