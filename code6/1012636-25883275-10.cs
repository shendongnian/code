    MemberStatusJournal memberStatusJournalAlias = null; // This will represent the 
                                                         // object of the outer query
    var subQuery = QueryOver.Of<MemberStatusJournal>()
                      .Select(Projections.GroupProperty(Projections.Property<MemberStatusJournal>(m => m.Member.ID)))
                      .Where(j => (j.EffectiveDate > firstOfMonth) && (j.PreviousId != null))
                      .Where(Restrictions.EqProperty(
                                 Projections.Min<MemberStatusJournal>(j => j.EffectiveDate),
                                 Projections.Property(() => memberStatusJournalAlias.EffectiveDate)
                             )
                            )
                      .Where(Restrictions.EqProperty(
                                Projections.GroupProperty(Projections.Property<MemberStatusJournal>(m => m.Member.Id)),
                                Projections.Property(() => memberStatusJournalAlias.Member.Id)
                           ));
    var results = session.QueryOver<MemberStatusJournal>(() => memberStatusJournalAlias)
                         .WithSubquery
                         .WhereExists(subQuery)
                         .List();
