    User u = new User();
    //...
    var tv= new TimelineVolumetry();
    //set required properties of TimelineVolumetry entity
    u.TimelineVolumetry =tv;
    //u.TimelineVolumetry.User = u;// you don't need to do this
    //...
    ctx.User.Add(u);
    ctx.SaveChanges();
