    var newClubKitOrders = from q in db.NewClubKitOrders where q.NewClubId == ncbId select q;
    
    if (newClubKitOrders.Any())
    {
        foreach (NewClubKitOrder order in newClubKitOrders)
        {
            if (checkedStatus == true)
            {
                order.OrderDate = DateTime.Now;
            }
            else
            {
                db.NewClubKitOrders.Remove(order);
            }
        }
        db.SaveChanges();
    }
