    namespace DomainLayer
    {
        public class Thing
        {
            public int Id;
        }
    
        internal class ThingEntityMapper
        {
            public static Thing Transform(ThingEntity thingEntity)
            {
                return new Thing{ Id = thingEntity.Id };
            }
        }
    
        internal interface IThingQueries
        {
            IQueryable<ThingEntity> FilterRelevent(IQueryable<ThingEntity> things);
        }
    
        internal class ThingQueries : IThingQueries
        {
            public IQueryable<ThingEntity> FilterRelevent(IQueryable<ThingEntity> things)
            {
                return things.Where(x => x.Id%2 == 0);
            }
        }
    
        public class ThingManager
        {
            private readonly DbContext _context;
            private readonly IThingQueries _queries;
            public ThingManager(DbContext _context, IThingQueries queries)
            {
                _context = context;
                _queries = queries;
            }
            public List<Thing> RelevantThings()
            {
                return _queries
                       .FilterRelevent(_context.ThingEntities)
                       .Select(ThingEntityMapper.Transform)
                       .ToList();
            } 
        }
    }
