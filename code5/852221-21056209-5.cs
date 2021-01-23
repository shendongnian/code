    public class BrandRepository
    {
        private readonly Context context;
        public BrandRepository(Context context)
        {
            this.context = context;
        }
        public void Add(Brand entity)
        {
            this.context.Brands.Add(entity);
        }
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
