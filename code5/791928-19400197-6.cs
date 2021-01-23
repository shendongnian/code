			static void Test3<T>(Expression<Func<T>> exp)
			{
				Expression body = exp.Body;
				List<string> memberNames = new List<string>();
				MemberInfo previousMember = null;
				while(body.NodeType == ExpressionType.MemberAccess)
				{
					MemberExpression memberBody = (MemberExpression)body;
					string memberName = memberBody.Member.Name;
					//If it's the 'last' member, replace with type
					if(memberBody.Expression.NodeType == ExpressionType.Constant && previousMember != null)
						memberName = previousMember.DeclaringType.name;
					memberNames.Add(memberName);
					previousMember = memberBody.Member;
					body = memberBody.Expression;
				}
				memberNames.Reverse();
				Console.WriteLine("Member: {0}", string.Join(".", memberNames));
			}
