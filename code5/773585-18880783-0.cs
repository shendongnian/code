        public IHttpActionResult Get(ODataQueryOptions<Person> oDataQueryOptions)
        {
            IQueryable result;
            IQueryable<Person> dataSet = context.Persons;
            IQueryable tempQuery = oDataQueryOptions.ApplyTo(dataSet);
            var modifier = new HierarchyNodeExpressionVisitor(GetDescendantsOfNode, GetAncestorsOfNode);
            var expression = modifier.ModifyHierarchyNodeExpression(tempQuery.Expression);
            result = context.Persons.Provider.CreateQuery(expression);
            return Ok(result, result.GetType());
        }
        private IHttpActionResult Ok(object content, Type type)
        {
            Type resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
            return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
        }
