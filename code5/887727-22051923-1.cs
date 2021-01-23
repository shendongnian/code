    public class Test 
    {
            public static  NextId(string table)
            {
                var db = new PrenDBContext();
                return MaxId = db.Raknare.Where(x => x.Column.Equals(table)).Max(x => x.ID) + 1;   
            } 
    }
