    var newClubKitOrders = from q in db.NewClubKitOrders where q.NewClubId == ncbId select q;
    
    if (newClubKitOrders.Any())
    {
    	var TempnewClubKitOrders = newClubKitOrders.ToList();
    
    	for(int i=0; i< TempnewClubKitOrders.Length; i++)
    	{
    		if (checkedStatus == true)
    		{
    			newClubKitOrders[i].OrderDate = DateTime.Now;
    		}
    		else
    		{
    			db.NewClubKitOrde.DeleteObject(newClubKitOrders[i]);
    		}
    	}
       
       db.SaveChanges();
    }
