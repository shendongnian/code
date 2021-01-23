    using NHibernate.Criterion;
    
    SelectList(l => l
      .Select(x => Projections.Concat(m.FirstName, ", ", m.LastName))
      .WithAlias(() => businessSectorItem.text))
    )
