    This is pretty involved, but if you want to use `DisplayName` inside of your QueryOver queries, you can actually tell QueryOver what accessing that property should translate into. 
    I actually wouldn't recommend this since it's pretty complicated and it duplicates logic (there would now be two places where `DisplayName` is defined). That said, it might be useful for others in a similar situation.
    Anyway, if you are curious (or more likely a glutton for QueryOver punishment) here's what that would look like:
        public static class PersonExtensions
        {
            /// <summary>Builds correct property access for use inside of 
            /// a projection.
            /// </summary>
            private static string BuildPropertyName(string alias, string property)
            {
                if (!string.IsNullOrEmpty(alias))
                {
                    return string.Format("{0}.{1}", alias, property);
                }
        
                return property;
            }
        
            /// <summary>
            /// Instructs QueryOver how to process the `DisplayName` property access
            /// into valid SQL.
            /// </summary>
            public static IProjection ProcessDisplayName(
                System.Linq.Expressions.Expression expression)
            {
                Expression<Func<Person, string>> firstName = p => p.FirstName;
                Expression<Func<Person, string>> lastName = p => p.LastName;
                
                string aliasName = ExpressionProcessor.FindMemberExpression(expression);
                
                string firstNameName = 
                    ExpressionProcessor.FindMemberExpression(firstName.Body);
                string lastNameName = 
                    ExpressionProcessor.FindMemberExpression(lastName.Body);
                
                PropertyProjection firstNameProjection = 
                    Projections.Property(BuildPropertyName(aliasName, firstNameName));
                PropertyProjection lastNameProjection = 
                    Projections.Property(BuildPropertyName(aliasName, lastNameName));
                
                return Projections.SqlFunction(
                    "concat",
                    NHibernateUtil.String,
                    lastNameProjection,
                    Projections.Constant(", "),
                    firstNameProjection);
            }
        }
    Then, you'd need to register the processing logic with NHibernate, probably right after your other configuration code:
        ExpressionProcessor.RegisterCustomProjection(
            () => default(Person).DisplayName,
            expr => PersonExtensions.ProcessDisplayName(expr.Expression));
    Finally, you'd be able to use your (unmapped) property inside of a QueryOver query:
        var people = session.QueryOver<Person>()
            .OrderBy(p => p.DisplayName).Asc            
            .List<Person>();
    Which generates the following SQL:
        SELECT 
	        this_.Id as Id0_0_,
	        this_.FirstName as FirstName0_0_,
	        this_.LastName as LastName0_0_
        FROM 
	        Person this_ 
        ORDER BY 
	        (this_.LastName + ', ' + this_.FirstName) asc
    You can find more about this technique [here][2]. **Disclaimer**: This is a link to my personal blog.
