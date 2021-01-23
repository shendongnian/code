    using (var ctx = DB.Get())
       {
       Items.AddRange(   
                      ctx.Interactions.Where(x => x.ActivityDate >= StartDateTo &&
                        x.ActivityDate <= EndDateTo && x.Indepth == true).Select(
                        x => new InteractionDTO()
                          {                              
                              Indepth = x.Indepth
                           }
                         )
                     );
    int count = Items.Count();
        }
