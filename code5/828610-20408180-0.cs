    public class ABC
    {
        public int AId { get; set; }
        public string AName { get; set; }
        // other stuff
    }
     // in your query
     select new ABC
     {
         AId = a.AId,
         AName = a.AName,
         BId = b.BId,
         CId = c.CId,
     }
