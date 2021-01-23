    Customer customer = null;
    Orders orders = null;
    // the subselect of a count
    var subQuery = QueryOver.Of<Orders>(() => orders)
        .Where(() => orders.Customer.ID == customer.ID)
        .Select(Projections.RowCount());
    // the alias of the Customer to be injected into subquery
    var query = session.QueryOver<Customer>(() => customer);
    query.SelectList(l => l
        .Select(p => p.Name).WithAlias(() => customer.Name)
        // see the customer.Count property
        .Select(Projections.SubQuery(subQuery)).WithAlias(() => customer.Count)
        );
    // Order by the count (desc)
    var list = query
        .OrderBy(Projections.SubQuery(subQuery))
            .Desc
        .TransformUsing(Transformers.AliasToBean<Customer>())
        .List<Customer>()
        ;
