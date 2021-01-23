    var result = db.ExecuteQuery<Dto>("SELECT SUM([Col1]) AS Sum1, SUM([Col2]) AS Sum2 FROM [dbo].[Statistics]")
    public class Dto
    {
        public int Sum1{get;set;}
        public int Sum2{get;set;}
    }
