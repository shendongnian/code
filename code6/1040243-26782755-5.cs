            if (obj == null) throw new NullReferenceException();
            var body = expr.Body as MemberExpression;
            if (body == null)
            {
                var ubody = (UnaryExpression)expr.Body;
                body = ubody.Operand as MemberExpression;
            }
            if (body != null)
            {
                var property = body.Member as PropertyInfo;
                if (property == null) throw;
                if (obj.GetType().GetProperty(property.Name).GetValue(obj, null) == null) throw new NullReferenceException();
            }
            else
            {
                var ubody = (UnaryExpression)expr.Body;
                var property = ubody.Operand as MemberExpression;
                if (property != null)
                    props[property.Member.Name] = obj.GetType()
                        .GetProperty(property.Member.Name)
                        .GetValue(obj, null);
                if (obj.GetType().GetProperty(property.Member.Name).GetValue(obj, null) == null) throw new NullReferenceException();
            }
        }
