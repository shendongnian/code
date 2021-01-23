    var query =_orchardServices.ContentManager.HqlQuery()
             .Join(alias=>alias.ContentPartRecord<AddResellerPartRecord>());
    var defaultHqlQuery = query as DefaultHqlQuery;
    var fiJoins = typeof(DefaultHqlQuery).GetField("_joins", BindingFlags.Instance | BindingFlags.NonPublic);
    var joins = fiJoins.GetValue(defaultHqlQuery) as List<Tuple<IAlias, Join>>;
    joins.Add(new Tuple<IAlias, Join>(new Alias("myproject.Core.Models"), new Join("ResellerPartRecord", "ResellerAlias", ",")));
    Action<IHqlExpressionFactory> joinOn = predicate => predicate.EqProperty("Id", "addResellerPartRecord.Reseller");
    query = query.Where(alias => alias.Named("ResellerAlias"), joinOn);
    query = query.Where(alias => alias.Named("ResellerAlias"), predicate => predicate.Like("Description", filterDescription, HqlMatchMode.Anywhere));
    var users = query.List();
