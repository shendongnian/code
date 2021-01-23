            var testObjects = new List<TestObject> 
            { 
                new TestObject { Value = 1, StringValue = "A" },
                new TestObject { Value = 2, StringValue = "B" }, 
                new TestObject { Value = 3, StringValue = "C" } 
            };
            var valueMemberInfo = typeof (TestObject).GetMember("Value").First();
            var stringValueMemberInfo = typeof (TestObject).GetMember("StringValue").First();
            var expressions = new List<Expression>();
            foreach (var to in testObjects)
            {
                var expr = Expression.MemberInit(
                    Expression.New(typeof(TestObject)),
                    Expression.Bind(valueMemberInfo, Expression.Constant(to.Value)),
                    Expression.Bind(stringValueMemberInfo, Expression.Constant(to.StringValue))
                );
                expressions.Add(expr);
            }
