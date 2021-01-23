    var newRuleConditions = new List<RuleCondition>();
    foreach (RuleCondition childItem in rule.RuleConditions)
    {
      if (childItem.RuleConditionId == 0)
      {
        oRuleCon = new RuleCondition();
        oRuleCon.Points = childItem.Points;
        oRuleCon.ConditionValue = childItem.ConditionValue;
        oRuleCon.ToOperatorId = childItem.ToOperatorId;
        oRuleCon.Sort = childItem.Sort;
    	//add to temporary list
        newRuleConditions.Add(oRuleCon);
        oAngieCtxt.RuleConditions.InsertOnSubmit(oRuleCon);
      }
      else
      {
        ...
      }
    }
    //add all new rule conditions
    rule.RuleConditions.AddRange(newRuleConditions);
