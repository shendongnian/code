    public class MainViewModel : ViewModelBase
    {
        private string _status;
        private Item _selectedItem;
        private ObservableCollection<Item> _items;
        public MainViewModel()
            :this(new ItemRepository(), new MedicineCompositionRepository())
        {}
        public MainViewModel(IRepository<Item> itemRepository, IRepository<MedicineComposition> medicineCompositionRepository)
        {
            ItemRepository = itemRepository;
            MedicineCompositionRepository = medicineCompositionRepository;
            Task.Run(() => LoadItemsData());
        }
        public IRepository<Item> ItemRepository { get; set; }
        public IRepository<MedicineComposition> MedicineCompositionRepository { get; set; }
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value; 
                OnPropertyChanged();
                Task.Run(() => LoadMedicineCompositionsData(_selectedItem));
            }
        }
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }
        private async Task LoadItemsData()
        {
            Status = "Loading items...";
            
            var result = await ItemRepository.GetAll();
            Items = new ObservableCollection<Item>(result);
            Status = "Idle";
        }
        private async Task LoadMedicineCompositionsData(Item item)
        {
            if (item.MedicineCompositions != null)
                return;
            Status = string.Format("Loading compositions for {0}...", item.Name);
            var result = await MedicineCompositionRepository.GetById(item.Id);
            SelectedItem.MedicineCompositions = result;
            Status = "Idle";
        }
    }
