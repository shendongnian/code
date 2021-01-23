    public class MyThingDataService
    {
       public IThing GetByID(int ID)
       {
          //EF code to query your database goes here, assuming you have a valid DBContext called "ctx". I won't go into how you might create or inject this, etc, as it's a separate topic e.g Dependency Injection.
         var thing = ctx.MyThings.FirstOrDefault();
         if (thing!=null)
        {
            return new MyThingDTO{ID=thing.ID, Data=thing.Data};
        }
        else{//handle the not found case here}
       }
    }
