    public static class SomeCategories
    {
        public enum PaymentCategory
        {
            Category1 = 1,
            Category2 = 2,
            Category3 = 3,
            Category4 = 4,
            Category5 = 5,
        }
        public static string ToDescription(this PaymentCategory category)
        {
            return category.ToString();
        }
    }
    public class SomeRentDb
    {
        static SomeRentRecord[] _records = new[]
        {
            new SomeRentRecord() { SiteId = 1, LandOwnerId = 2, PaymentCategoryId = 4, PaymentTypeId = 3, PropertyName = "Propery 1" },
            new SomeRentRecord() { SiteId = 1, LandOwnerId = 4, PaymentCategoryId = 2, PaymentTypeId = 4, PropertyName = "Propery 2" },
            new SomeRentRecord() { SiteId = 2, LandOwnerId = 4, PaymentCategoryId = 3, PaymentTypeId = 5, PropertyName = "Propery 3" },
            new SomeRentRecord() { SiteId = 3, LandOwnerId = 5, PaymentCategoryId = 4, PaymentTypeId = 6, PropertyName = "Propery 4" },
            new SomeRentRecord() { SiteId = 4, LandOwnerId = 4, PaymentCategoryId = 1, PaymentTypeId = 7, PropertyName = "Propery 5" },
            new SomeRentRecord() { SiteId = 5, LandOwnerId = 5, PaymentCategoryId = 5, PaymentTypeId = 8, PropertyName = "Propery 6" },
        };
        public class SomeRentRecord
        {
            public int SiteId;
            public int LandOwnerId;
            public int PaymentCategoryId;
            public int PaymentTypeId;
            public string PropertyName;
        }
        public IQueryable<SomeRentRecord> All
        {
            get { return _records.AsQueryable(); }
        }
        public IQueryable<SomeRentRecord> RecordsWhere(Expression<Func<SomeRentRecord, bool>> expr)
        {
            return _records.AsQueryable().Where(expr);
        }
    }
    public class RentPaidReportRecord
    {
        public int SiteId;
        public int LandOwnerId;
        public int PaymentCategoryId;
        public int PaymentTypeId;
        public string PropertyName;
        public string Category;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SomeRentDb();
            var result = db.All;
            var paymentCategoryValues =
                    Enum.GetValues(typeof(SomeCategories.PaymentCategory)).Cast<SomeCategories.PaymentCategory>().Select
                        (r => new KeyValuePair<int, string>((int)r, r.ToDescription()));
            var searchResults = from s in result
                                from c in paymentCategoryValues
                                where s.LandOwnerId == 4 && s.PaymentCategoryId == c.Key
                                select new RentPaidReportRecord()
                                {
                                    SiteId = s.SiteId,
                                    LandOwnerId = s.LandOwnerId,
                                    PaymentCategoryId = s.PaymentCategoryId,
                                    PaymentTypeId = s.PaymentTypeId,
                                    PropertyName = s.PropertyName,
                                    Category = c.Value
                                };
            var searchResults2 = from s in result
                                 from c in paymentCategoryValues
                                 where s.LandOwnerId == 4 && s.PaymentCategoryId == c.Key
                                 select new 
                                 {
                                     SiteId = s.SiteId,
                                     LandOwnerId = s.LandOwnerId,
                                     PaymentCategoryId = s.PaymentCategoryId,
                                     PaymentTypeId = s.PaymentTypeId,
                                     PropertyName = s.PropertyName,
                                     Category = c.Value
                                 };
            foreach (var r in searchResults)
                Console.WriteLine("{0} - {1}", r.PropertyName, r.Category);
            foreach (var r in searchResults2)
                Console.WriteLine("{0} - {1}", r.PropertyName, r.Category);
            Console.ReadLine();
        }
    }
