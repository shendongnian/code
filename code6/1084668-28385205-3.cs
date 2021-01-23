    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetById(int id);
    }
    public class ItemRepository : IRepository<Item>
    {
        private readonly IList<Item> _mockItems; 
        
        public ItemRepository()
        {
            _mockItems = new List<Item>();
            for (int i = 0; i < 100; i++)
                _mockItems.Add(new Item { Id = i, Name = string.Format("Item #{0}", i), MedicineCompositions = null });
        }
        public Task<IEnumerable<Item>> GetAll()
        {
            Thread.Sleep(1500);
            return Task.FromResult((IEnumerable<Item>) _mockItems);
        }
        public Task<IEnumerable<Item>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
    public class MedicineCompositionRepository : IRepository<MedicineComposition>
    {
        private readonly Random _random;
        public MedicineCompositionRepository()
        {
             _random = new Random();
        }
        public Task<IEnumerable<MedicineComposition>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<MedicineComposition>> GetById(int id)
        {
            var compositions = new List<MedicineComposition>();
            int compositionsCount = _random.Next(1, 3);
            for (int i = 0; i <= compositionsCount; i++)
            {
                var components = new List<Component>();
                int componentsCount = _random.Next(1, 3);
                for (int j = 0; j <= componentsCount; j++)
                    components.Add(new Component {Id = j, Name = string.Format("Component #1{0}", j)});
                compositions.Add(new MedicineComposition { Id = i, Name = string.Format("MedicalComposition #{0}", i), Components = components });
            }
            Thread.Sleep(500);
            return Task.FromResult((IEnumerable<MedicineComposition>) compositions);
        }
    }
