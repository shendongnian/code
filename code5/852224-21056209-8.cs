    public class BrandRepository
    {
        private readonly Context context;
        public BrandRepository(Context context)
        {
            this.context = context;
        }
        public void Add(Brand brand)
        {
            this.context.Brands.Add(brand);
        }
        public Brand FindByName(string name)
        {
            return this.context.Brands.Single(b => b.Name == name);
        }
        public void RemoveCarModel(Brand brand, string carModelName)
        {
            var carModelToRemove = brand.Models.Single(cm => cm.Name == "A car model");
            brand.Models.Remove(carModelToRemove);
        }
        public void Save()
        {
            context.SaveChanges();
        }
