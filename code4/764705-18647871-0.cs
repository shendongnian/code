    //With Auto detect changes off.
    foreach(var batch in batches)//keep batch size below 1000 items, play around with the numbers a little
    {
        using(var ctx = new MyContext())//make sure you create a new context per batch.
        {
            foreach(var entity in batch){
                 ctx.Entities.Add(entity);
            }
            ctx.SaveChanges();
        }
    }
