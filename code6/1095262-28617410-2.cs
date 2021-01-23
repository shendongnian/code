    Receivers receiversSubQueryAlias = null;
    var subquery = session.QueryOver<Events>()
                          .JoinQueryOver<Receivers>(x => x.Receivers, () => receiversSubqueryAlias, JoinType.Inner)
                          .Where(()=> receiversSubQueryAlias.UserId == 1)
                          .Select(x => x.Id)
                          .TransformUsing(Transformers.DistinctRootEntity);
    Events eventsAlias = null;
    var mainQueryResults = session.QueryOver<Events>(() => eventsAilas)
                           .Where(Restrictions.Disjunction()
                                 .Add(() => eventAlias.OwnerId == 1)
                                 .Add(() => eventAlias.EVType.Id == 123)
                                 .Add(Subqueries.WhereProperty<Events>(() => eventAlias.Id).In(subquery))
                            ).Select(x => x.StartDate)
                            .TransformUsing(Transformers.DistinctRootEntity)
                            .List();
