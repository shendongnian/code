    public Guest CreateGuest(Guest guest)
    {
         guest.GuestOnline = true;
         context.Guests.InsertOnSubmit(guest);
         context.SubmitChanges(); //context.SaveChanges() for LINQ to Entity
     
         return guest;
    }
