        var criteria = Session.CreateCriteria<DtaMonthFreeze>()
            .Add(regionId.HasValue ? Restrictions.Eq("BranchGroupId", regionId) : Restrictions.IsNull("BranchGroupId"))
            .Add(Restrictions.Eq(Projections.SqlFunction("MONTH", NHibernateUtil.DateTime, Projections.Property<DtaMonthFreeze>(x => x.Date)), monthDate.Month))
            .Add(Restrictions.Eq(Projections.SqlFunction("YEAR", NHibernateUtil.DateTime, Projections.Property<DtaMonthFreeze>(x => x.Date)), monthDate.Year))
            .Add(Restrictions.Eq("IsFrozen", true));
        var result = criteria.List<DtaMonthFreeze>();
        return result.Any();
