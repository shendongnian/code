    private void VisitMemberAccess(MemberExpression expression, MemberExpression left)
    {
        var key = left != null ? left.Member.Name : expression.Member.Name;
        if (expression.Expression.NodeType.ToString() == "Parameter")
        {
            // add the string key
            _strings.Add(string.Format("[{0}]", key));
        }
        else
        {
            // add the string parameter
            _strings.Add(string.Format("@{0}", key));
            var value = new object();
            if ((expression.Member as PropertyInfo) != null)
            {
                var exp = (MemberExpression) expression.Expression;
                var constant = (ConstantExpression) exp.Expression;
                var fieldInfoValue = ((FieldInfo) exp.Member).GetValue(constant.Value);
                value = ((PropertyInfo) expression.Member).GetValue(fieldInfoValue, null);
            }
            else if ((expression.Member as FieldInfo) != null)
            {
                var fieldInfo = expression.Member as FieldInfo;
                var constantExpression = expression.Expression as ConstantExpression;
                if (fieldInfo != null & constantExpression != null)
                {
                    value = fieldInfo.GetValue(constantExpression.Value);
                }
            }
            else
            {
                throw new InvalidMemberException();
            }
            // add parameter value
            Parameters.Add("@" + key, value);
        }
    }
