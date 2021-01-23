    public class testClass{
        public IQueryable<MyClass> TestMethod(){
            return from m in db.testTable
            join n in db.testTable2
            on m.ID equals n.ID into tabA
            from a in tabA
            join o in db.testTable3
            on m.UserID equals o.ID
            select new MyClass{ .................};
        }
    }    
