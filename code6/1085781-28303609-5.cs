    namespace Foo.Api
    {
        public class BarController : ApiController
        {
            private FooContext db = new FooContext(); 
            public IQueryable<Bar> GetBar(string bla)
            {
                 return db.Bar.Where(f => f.Category.Equals(bla)).OrderBy(f => f.Year);
            }
            // WebApi 2 will call this automatically after each 
            // request. You need this to ensure your context is disposed
            // and the memory it is using is freed when your app does garbage 
            // collection.
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
