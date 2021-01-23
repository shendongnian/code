    public class CarModel
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Name { get; set; }
        [Key, ForeignKey("Brand"), Column(Order=1)]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
.
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
