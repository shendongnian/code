    public static IQueryable<Order> ActiveOrdersQuery(this MyDBEntities db)
    {
        return db.orders.Where(
               o=> o.Active && 
                   (o.TransactionType == TransactionType.Order ||
                    o.TransactionType == TransactionType.Subscription )));
             
    }
    public IQueryable<UserView> GetView()
    {
        var q = context.ActiveOrdersQuery();
        return context.users.Select( x=> new UserView{
             Id = x.Id,
             Active = q.Any( o=> o.UserId == x.Id)
        });
    }
