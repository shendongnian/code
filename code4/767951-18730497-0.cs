    public static bool First() {
        using (Entities db = new Entities()) {
            DateTime FirstValue = (
                from a in db.Table
                select a.Timestamp
            ).FirstOrDefault();
    
    
    public static bool Second() {              
        using (Entities db = new Entities()) {
            DateTime SecondValue = (
                from a in db.Table
                select a.Timestamp
            ).Skip(1).FirstOrDefault();
