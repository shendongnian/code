     public class BaseController : ApiController
        {
            protected JavaCertContext db = new JavaCertContext();
    
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
    
                base.Dispose(disposing);
            }
        }
    
        public class ChildController : BaseController
        {
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_userManager != null)
                    {
                        _userManager.Dispose();
                        _userManager = null;
                    }
                }
    
                base.Dispose(disposing);
            }
        }
    
        public class ApiController
        {
            private volatile bool _isDiposed;
    
            public void Dispose()
            {
                if (_isDiposed)
                {
                    return;
                }
    
                Dispose(true);
    
                _isDiposed = true;
            }
    
            protected virtual void Dispose(bool isDisposing)
            {
                if (isDisposing)
                {
                    //Dispose stuff.
                }
            }
        }
    
        public class JavaCertContext
        {
        }
