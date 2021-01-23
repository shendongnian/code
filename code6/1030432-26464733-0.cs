      public class RatingRepo : GenericRepository<Rating>
            {
                private GenericSaveRepository<Rating> gen;
                private readonly NaijaSchoolsContext _context;
                public RatingRepo(NaijaSchoolsContext context)
                    : base(context)
                {
                    _context = context;
        
                }
        
                public void Save(School school, Rating rating)
                {
        
                    List<Rating> ratings = new List<Rating>();
                    ratings.Add(rating);
                    gen = new GenericSaveRepository<Rating>(_context);
                    gen.Save(23, ratings);
                }
            }
