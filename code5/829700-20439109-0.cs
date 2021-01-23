     public abstract class DBController : Controller {
         public MyDbContext DbContext { get; private set; }
         public DBController() {
             DbContext = new ... 
             HttpContext.Items["DbContext"] = DbContext;
         }
         protected override void OnDispose() {
             DbContext.Dispose();
         }
     }
