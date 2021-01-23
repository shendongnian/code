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
     // omitted fetch of sqlResults
     var grouped = sqlResults.AsEnumerable()
          .ToLookup(
               item => new
               {
                    Location = item.Location
               }),
               item => new
               {
                    Person = item.Person
               });
