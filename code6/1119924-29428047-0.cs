    public class ClassificationTranslationVisitor : ExpressionVisitor
    {
        private string langCode = "en";
        private string defaultLangCode = "en";
        private string memberName = null;
        private Expression originalNode = null;
        public ClassificationTranslationVisitor(string langCode, string defaultLanguageCode)
        {
            this.langCode = langCode;
            this.defaultLangCode = defaultLanguageCode;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (langCode == defaultLangCode)
            {
                return base.VisitParameter(node);
            }
            if (!node.Type.GetCustomAttributes(typeof(TranslatableAttribute), false).Any() && originalNode == null)
            {
                return base.VisitParameter(node);
            }
            if (IsGenericInterface(node.Type, typeof(ITranslatableEntity<>)))
            {
                return AddTranslation(node);
            }
            return base.VisitParameter(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null || node.Member == null || node.Member.DeclaringType == null)
            {
                return base.VisitMember(node);
            }
            if (langCode == defaultLangCode)
            {
                return base.VisitMember(node);
            }
            if (!node.Member.GetCustomAttributes(typeof(TranslatableAttribute), false).Any() && originalNode == null)
            {
                return base.VisitMember(node); 
            }
            if (IsGenericInterface(node.Member.DeclaringType, typeof(ITranslatableEntity<>)))
            {
                memberName = node.Member.Name;
                originalNode = node;
                return Visit(node.Expression);
            }
            if (IsGenericInterface(node.Type, typeof(ITranslatableEntity<>)))
            {
                return AddTranslation(node);
            }
            return base.VisitMember(node);
        }
        private Expression AddTranslation(Expression node)
        {
            var expression = Expression.Property(node, "Translations");
            var resultWhere = CreateWhereExpression(expression);
            var resultSelect = CreateSelectExpression(resultWhere);
            var resultIsNull = Expression.Equal(resultSelect, Expression.Constant(null));
            var testResult = Expression.Condition(resultIsNull, originalNode, resultSelect);
            memberName = null;
            originalNode = null;
            return testResult;
        }
        private Expression CreateWhereExpression(Expression ex)
        {
            var type = ex.Type.GetGenericArguments().First();
            var test = CreateExpression(t => t.LanguageCode == langCode, type);
            if (test == null)
                return null;
            return Expression.Call(typeof(Enumerable), "Where", new[] { type }, ex, test);
        }
        private Expression CreateSelectExpression(Expression ex)
        {
            var type = ex.Type.GetGenericArguments().First();
            ParameterExpression itemParam = Expression.Parameter(type, "lang");
            Expression selector = Expression.Property(itemParam, memberName);
            var columnLambda = Expression.Lambda(selector, itemParam);
            var result = Expression.Call(typeof(Enumerable), "Select", new[] { type, typeof(string) }, ex, columnLambda);
            var stringResult = Expression.Call(typeof(Enumerable), "FirstOrDefault", new[] { typeof(string) }, result);
            return stringResult;
        }
        /// <summary>
        /// Adapt a QueryConditional to the member we're currently visiting.
        /// </summary>
        /// <param name="condition">The condition to adapt</param>
        /// <param name="type">The type of the current member (=Navigation property)</param>
        /// <returns>The adapted QueryConditional</returns>
        private LambdaExpression CreateExpression(Expression<Func<ITranslation, bool>> condition, Type type)
        {
            var lambda = (LambdaExpression)condition;
            var conditionType = condition.GetType().GetGenericArguments().First().GetGenericArguments().First();
            // Only continue when the condition is applicable to the Type of the member
            if (conditionType == null)
                return null;
            if (!conditionType.IsAssignableFrom(type))
                return null;
            var newParams = new[] { Expression.Parameter(type, "bo") };
            var paramMap = lambda.Parameters.Select((original, i) => new { original, replacement = newParams[i] }).ToDictionary(p => p.original, p => p.replacement);
            var fixedBody = ParameterRebinder.ReplaceParameters(paramMap, lambda.Body);
            lambda = Expression.Lambda(fixedBody, newParams);
            return lambda;
        }
        private bool IsGenericInterface(Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == interfaceType);
        }
    }
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
        }
    }
