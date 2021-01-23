    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            Search<Student>(s => s.Id == 1L);
            GetStudent(1L);
        }
        private void GetStudent(long id)
        {
            Search<Student>(s => s.Id == id);
        }
        private void Search<T>(Expression<Func<T, bool>> filter)
        {
            var visitor = new MyExpressionVisitor2();
            visitor.Visit(filter.Body);
        }
    }
    //ExpressionVisitor
    public class MyExpressionVisitor2 : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            switch (node.Expression.NodeType)
            {
                case ExpressionType.Constant:
                case ExpressionType.MemberAccess:
                {
                    var cleanNode = GetMemberConstant(node);
                    
                    //Test
                    Assert.AreEqual(1L, cleanNode.Value);
                    return cleanNode;
                }
                default:
                {
                    return base.VisitMember(node);
                }
            }
        }
        private static ConstantExpression GetMemberConstant(MemberExpression node)
        {
            object value;
            if (node.Member.MemberType == MemberTypes.Field)
            {
                value = GetFieldValue(node);
            }
            else if (node.Member.MemberType == MemberTypes.Property)
            {
                value = GetPropertyValue(node);
            }
            else
            {
                throw new NotSupportedException();
            }
            return Expression.Constant(value, node.Type);
        }
        private static object GetFieldValue(MemberExpression node)
        {
            var fieldInfo = (FieldInfo)node.Member;
            var instance = (node.Expression == null) ? null : TryEvaluate(node.Expression).Value;
            return fieldInfo.GetValue(instance);
        }
        private static object GetPropertyValue(MemberExpression node)
        {
            var propertyInfo = (PropertyInfo)node.Member;
            var instance = (node.Expression == null) ? null : TryEvaluate(node.Expression).Value;
            return propertyInfo.GetValue(instance, null);
        }
        private static ConstantExpression TryEvaluate(Expression expression)
        {
           
            if (expression.NodeType == ExpressionType.Constant)
            {
                return (ConstantExpression)expression;
            }
            throw new NotSupportedException();
        }
    }
