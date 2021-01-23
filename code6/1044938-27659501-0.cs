    query.AddLink(B.EntityLogicalName, "a_id", "b_one_id", JoinOperator.LeftOuter);
    query.LinkEntities[0].EntityAlias = "connectionB";
    query.LinkEntities[0].LinkCriteria.AddCondition("b_two_id", ConditionOperator.Equal, 1);
    
    query.AddLink(C.EntityLogicalName, "a_id", "c_one_id", JoinOperator.LeftOuter);
    query.LinkEntities[0].EntityAlias = "connectionC";
    query.LinkEntities[0].LinkCriteria.AddCondition("c_two_id", ConditionOperator.Equal, 2);
