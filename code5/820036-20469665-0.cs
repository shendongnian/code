    RelationPredicateBucket preFilter = new RelationPredicateBucket();
    preFilter.Relations.Add(GroupAgentEntity.Relations.AgentSplitGroupEntityUsingAgentSplitGroupId);
    preFilter.PredicateExpression.Add(AgentSplitGroupFields.Name == "Broker");
    PrefetchPath2 pre = new PrefetchPath2((int)EntityType.AgentGroupEntity);
    pre.Add(AgentGroupEntity.PrefetchPathAgentSplitGroup, 0, preFilter.PredicateExpression, preFilter.Relations);
