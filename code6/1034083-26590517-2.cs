    InvoiceLineItem lineItemAlias = null;
  
    session.QueryOver<InvoiceLineItem>(() => lineItemAlias)
        .SelectList(list => list
            .Select(Projections.Sum(
                Projections.SqlFunction(new VarArgsSQLFunction("(", "*", ")"),
                NHibernateUtil.Double,
                Projections.Property(() => lineItemAlias.Quantity),
                Projections.Property(() => lineItemAlias.UnitPrice))))
            .SelectGroup(() => lineItemAlias.Invoice.Id)
       // TransformUsing, List<>, etc.
