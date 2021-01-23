    var ci = dynamicType.GetConstructors().Single();
    var selector =
        Expression.Lambda(
            Expression.New(
                ci,
                ci.GetParameters()
                  .Select(
                      p => Expression.Property(
                          paramEx, dictIndex.Values.Single(x => x.Name == p.Name))),
                ci.GetParameters().Select(p => dynamicType.GetField(p.Name))),
            paramEx);
