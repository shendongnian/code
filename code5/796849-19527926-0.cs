    var senderUA = session.CreateCriteria<UserAlert>()
                      .Add(Restrictions.Eq("EntityId", id))
                      .AddOrder(Order.Desc("UserAlertId"))
                      .SetMaxResults(1)
                      .UniqueResult();
