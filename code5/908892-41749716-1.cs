    public class GetRelevantDbObjectsQuery : IRequest<DbObject[]> {
      // no input needed for this particular request,
      // but you would simply add plain properties here if needed
    }
    
    public class GetRelevantDbObjectsEFQueryHandler : IRequestHandler<GetRelevantDbObjectsQuery, DbObject[]> {
      private readonly IDbContext _db;
    
      public GetRelevantDbObjectsEFQueryHandler(IDbContext db) {
        _db = db;
      }
    
      public DbObject[] Handle(GetRelevantDbObjectsQuery message) {
        return _db.DbObjects.Where(foo => bar).ToList();
      }
    }
