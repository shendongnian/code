    	public bool InsertBooking(Booking obj)
        {
            using(var db  = new Model1Entities())
			{
				db.Bookings.Attach(obj);
				db.Bookings.Add(obj);
				
				db.SaveChanges();
			}
            return true; // or return obj
        }
