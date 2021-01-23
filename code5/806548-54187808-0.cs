    using System.Data.Entity.SqlServer;    
    ...
    date = SqlFunctions.DatePart("year",g.Key)
        +"-"+SqlFunctions.DatePart("month",g.Key)
        +"-"+SqlFunctions.DatePart("day",g.Key)
