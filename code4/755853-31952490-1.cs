    public IList<PersonnelPresence> GetLastPersonnelPresencesForPeopleExternalIds(IList<string> externalIds)
    {
	    var criteriaPersonnelPresenceNewest = DetachedCriteria.For<PersonnelPresence>("PP_")
													.Add(Restrictions.In("PP_.ExternalId", externalIds.ToArray()()))
													.Add(Restrictions.EqProperty("PP_.ExternalId", "PP2_.ExternalId"))//to compare with the query down below
													.SetProjection(Projections.ProjectionList()
																			  .Add(Projections.Max("PP_.StartTime"))
													);
													
	var criteriaPersonnelPresence = Session.CreateCriteria<PersonnelPresence>("PP2_")													
											.Add(Subqueries.PropertyEq("PP2_.StartTime", criteriaPersonnelPresenceNewest))
											.SetProjection(Projections.ProjectionList()
																	  .Add(Projections.Property("PP2_.Id"))
																	  .Add(Projections.Property("PP2_.StartTime"))
											)
											.ToList<PersonnelPresence>();
	return criteriaPersonnelPresence;
    }
