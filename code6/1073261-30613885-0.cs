    public class ItemViewModel
    {
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public Type PageType { get; set; }
        public ICommand ItemTappedCommand { set; get; }
    }
