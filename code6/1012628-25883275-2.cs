    MemberStatusJournal memberStatusJournalAlias = null;
    var subQuery = QueryOver.Of<MemberStatusJournal>()
                      .Select(Projections.GroupProperty(Projections.Property<MemberStatusJournal>(m => m.Member.ID))
                      .Where(j => (j.EffectiveDate > firstOfMonth) && (j.PreviousId != null))
                      .Where(Restrictions.EqProperty(
                                 Projections.Min<MemberStatusJournal>(j => j.EffectiveDate),
                                 Projections.Property(() => memberStatusJournalAlias.EffectiveDate)
                             )
                            );
    var results = session.QueryOver<MemberStatusJournal>(() => memberStatusJournalAlias)
                         .WithSubquery
                                .WhereProperty(m => m.Member.Id)
                                     .In(subQuery)
                         .List();
