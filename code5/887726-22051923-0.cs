    public class Test 
    {
            private static PrenDBContext db = new PrenDBContext();
        
            public static  NextId(string table)
            {
                return MaxId = db.Raknare.Where(x => x.Column.Equals(table)).Max(x => x.ID) + 1;
            } 
    }
