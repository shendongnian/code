    class MainViewModel
    {
        public List<BlockViewModel> Blocks { get; set; }
        public MainViewModel()
        {
            Blocks = new List<BlockViewModel> { new BlockViewModel() };
        }
    }
