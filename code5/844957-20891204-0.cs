     _dbSess.CreateCriteria<ClientFile>()
     .Add(Restrictions.Or(Restrictions.Eq("Status", 5), Restrictions.Eq("Status", 6)))
     .Add(Restrictions.Or(Restrictions.Eq("ReassignedTo", UserId), Restrictions.And(Restrictions.IsNull("ReassignedTo"), Restrictions.Eq("DispatchedTo", UserId))))
     .Add(Restrictions.And(Restrictions.Ge("ReadyDate", from), Restrictions.Le("ReadyDate", to)))
     .List<ClientFile>();
