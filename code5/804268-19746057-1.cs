    private void VisitMemberAccess(MemberExpression expression, MemberExpression left)
    {
        // To preserve Case between key/value pairs, we always want to use the LEFT side of the expression.
        // therefore, if left is null, then expression is actually left. 
        // Doing this ensures that our `key` matches between parameter names and database fields
        var key = left != null ? left.Member.Name : expression.Member.Name;
        // If the NodeType is a `Parameter`, we want to add the key as a DB Field name to our string collection
        // Otherwise, we want to add the key as a DB Parameter to our string collection
        if (expression.Expression.NodeType.ToString() == "Parameter")
        {
            _strings.Add(string.Format("[{0}]", key));
        }
        else
        {
            _strings.Add(string.Format("@{0}", key));
            // If the key is being added as a DB Parameter, then we have to also add the Parameter key/value pair to the collection
            // Because we're working off of Model Objects that should only contain Properties or Fields,
            // there should only be two options. PropertyInfo or FieldInfo... let's extract the VALUE accordingly
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
            // Add the Parameter Key/Value pair.
            Parameters.Add("@" + key, value);
        }
    }
