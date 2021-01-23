    public class SystemService : ISystemService
    {
        private readonly IContext _context;
        public SystemService(IContext context)
        {
            _context = context;
        }
        public Models.System AddSystem(Models.System system)
        {
            var s = _context.Systems.Add(system);
            _context.SaveChanges();
            return s;
        }
        public Models.System GetSystem(int id)
        {
            return _context.Systems.Find(id);
        }
    }
