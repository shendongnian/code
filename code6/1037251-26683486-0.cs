    using System;
    using System.Data;
    namespace Services.ResourceAccess
    {
        public class ResourceAccess : IDisposable
        {
            private readonly Lazy<MyDbEntities> _context;
            public ResourceAccess()
            {
                _context = new Lazy<MyDbEntities>(() =>
                {
                    var context = new MyDbEntities();
                    context.Database.Connection.Open();
                    return context;
                });
            }
            public void DeleteGroupDetails(int groupId)
            {
                var deleted = _context.Value.tblGroupDetails.Where(x => x.GroupID == groupId);
                _context.Value.tblGroupDetails.RemoveRange(deleted);
                _context.Value.SaveChanges();
            }
            public void Dispose()
            {
                if (_context.IsValueCreated)
                {
                    if (_context.Value.Database.Connection.State == ConnectionState.Open)
                    {
                        _context.Value.Database.Connection.Close();
                    }
                }
            }
        }
    }
