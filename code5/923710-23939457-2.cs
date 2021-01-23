    using System.Web;
    namespace DataLayer.Common
    {
        public class ConnectionHelper : IConnectionHelper
        {
            private ApplicationDbContext _context;
            public ApplicationDbContext Context
            {
                get
                {
                    if (_context == null && HttpContext.Current.Items["DbActiveContext"] != null)
                    {
                        _context = (ApplicationDbContext)HttpContext.Current.Items["DbActiveContext"];
                    }
                    else if (_context == null && HttpContext.Current.Items["DbActiveContext"] == null)
                    {
                        _context = new ApplicationDbContext();
                        HttpContext.Current.Items.Add("DbActiveContext", _context);
                    }
                
                    return _context;
                }
                set { _context = value; }
            }
        }
    }
