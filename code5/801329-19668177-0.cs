    var memberGoals = from v in doc.Root.Descendants(Common.Constants.NameSpace + "memberGoal")
                                  select new MemberGoalModel
                                  {
                                      goalDescription = v.Element(Common.Constants.NameSpace + "goalDescription").Value,
    //Assign Other Properties here. 
                                  };
                //return Deserialize<MemberCarePlanModel>(ms);
                return memberGoals.ToList()
