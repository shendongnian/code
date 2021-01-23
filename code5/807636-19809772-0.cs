     public class TestableCsvActionResult : CsvActionResult
     {
         public TestableCsvActionResult(DataTable dt)
        : base(dt)
         {
         }
         public new void WriteFile(HttpResponseBase response)
         { base.WriteFile(response); }
     }
