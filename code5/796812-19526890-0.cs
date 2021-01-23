    public class DataItem
    {
         public string Location
         {
             get;
             set;
         }
         public string Person
         {
             get;
             set;
         }
     }
     var grouped = tcs.AsEnumerable()
          .ToLookup(
               item => new
               {
                    Location = item.Location
               }),
               item => new
               {
                    Person = item.Person
               });
