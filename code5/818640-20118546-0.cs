     Context.Entry(poco).State = state; // tell ef what is going on.
     Context.SaveChanges();
    //    Detached = 1,
    //    Unchanged = 2,
    //    Added = 4,
    //    Deleted = 8,
    //   Modified = 16,
