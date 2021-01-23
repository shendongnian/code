    var list = condRegardingObjectId.Values;
    foreach(EntityOpportunity opt in entAccount.Opportunities) {
        foreach(EntityActivityPointer activity in opt.Activities) {
            list.Add(activity.Id);
        }
    }
