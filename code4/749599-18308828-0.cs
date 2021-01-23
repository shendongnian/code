        private static string GetMethodNameInternal(Type @this, MethodCallExpression bodyExpression)
        {
            if (bodyExpression == null)
                throw new ArgumentException("Body of the exspression should be of type " + typeof(MethodCallExpression).Name);
            var member = bodyExpression.Method;
            if (member.MemberType != MemberTypes.Method)
                throw new ArgumentException("MemberType of the exspression should be of type " + MemberTypes.Method);
            if (!object.Equals(@this, member.DeclaringType))
                throw new ArgumentException("Invalid property owner.");
            return member.Name;
        }
