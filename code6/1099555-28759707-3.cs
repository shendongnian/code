    public class MyBal : IBalService
    {
        public void Insert()
        {
            using (MyEntities context = new MyEntities ())
            {
                var result = context.MyTable.Add(_MyTable);
                context.SaveChanges();
                return result;
            }
    }
