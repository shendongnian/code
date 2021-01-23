    public class ThemeService
    {
        private IRepository<Theme> ThemeRepository { get; set; }
        public ThemeService(IRepository<Theme> themeRepo)
        {
            ThemeRepository = themeRepo;
        }
         
        public List<Theme> GetAll(int page = 1, int pageSize = 10)
        {
            return ThemeRepository.Get(null, null, "Comments", page, pageSize).ToList();
        }
        
        // etc.
    }
