    using (var db = new Database1Entities("..."))
    {
         var my = db.A.LeftOuterJoin2(db.B, a => a.Id, b => b.IdA, 
             (a, b) => new { a, b, hello = "Hello World! I'm available for vacancy!" });
         // other actions ...
    }
