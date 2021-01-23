    int value = 5;
    var xParameter = Expression.Parameter(typeof(T), "x");
    var oParameter = Expression.Parameter(typeof(Organization), "o");
    var expression =
        Expression.Lambda(
            Expression.Call(
                typeof(Queryable), "Any", new[] { typeof(Organization) },
                Expression.Property(xParameter, "OrganizationPersonRoles"),
                Expression.Constant(
                    Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(oParameter, "OrganizationId"),
                            Expression.Constant(value, typeof(int))),
                        oParameter)),
                    typeof(Expression<Func<Organization, bool>>)),
            xParameter);
